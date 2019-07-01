using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Pliance.SDK
{
    public class PlianceClientFactory
    {
        public PlianceClientFactory(string secret, string company, string issuer, string url, X509Certificate2 certificate = null)
        {
            _secret = secret;
            _company = company;
            _issuer = issuer;
            _url = url;
            _certificate = certificate;
        }

        public HttpClient Create(string givenName, string subject)
        {
            if (_client != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CreateJwtToken(givenName, subject));
                
                return _client;
            }

            var handler = new HttpClientHandler();

            handler.SslProtocols = SslProtocols.Tls12;

            if (_certificate != null)
            {
                handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                handler.ClientCertificates.Add(_certificate);
            }

            var client = new HttpClient(handler);
            client.BaseAddress = new Uri(_url);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CreateJwtToken(givenName, subject));

            return client;
        }

        private string CreateJwtToken(string givenName, string subject)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var token = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _issuer,
                Audience = "pliance.io",
                Expires = DateTime.UtcNow.AddSeconds(300),
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim("given_name", givenName),
                    new Claim("sub", subject),
                }),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha512Digest)
            });

            var tokenString = handler.WriteToken(token);

            return tokenString;
        }

        private string _secret;
        private string _company;
        private string _issuer;
        private string _url;
        private X509Certificate2 _certificate;
        private HttpClient _client;
    }
}
