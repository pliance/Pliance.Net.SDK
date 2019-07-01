using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Nito.AsyncEx;

namespace Pliance.SDK
{
    public class PlianceClientFactory
    {
        private string _secret;
        private string _issuer;
        private string _url;
        private X509Certificate2 _certificate;
        private Stack<HttpClient> _clients = new Stack<HttpClient>();
        private AsyncMonitor _monitor = new AsyncMonitor();

        public PlianceClientFactory(string secret, string issuer, string url, X509Certificate2 certificate = null, int poolSize = 8)
        {
            _secret = secret;
            _issuer = issuer;
            _url = url;
            _certificate = certificate;

            foreach (var i in Enumerable.Range(0, poolSize))
            {
                _clients.Push(CreateHttpClient());
            }
        }

        public PlianceClient Create(string givenName, string subject)
        {
            return new PlianceClient(this, givenName, subject);
        }

        public async Task<T> Execute<T>(Func<HttpClient, Task<T>> action, string givenName, string subject)
        {
            HttpClient client;

            using (await _monitor.EnterAsync())
            {
                while (_clients.Count == 0)
                {
                    await _monitor.WaitAsync();
                }

                client = _clients.Pop();
            }

            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CreateJwtToken(givenName, subject));
                return await action(client);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                using (await _monitor.EnterAsync())
                {
                    _clients.Push(client);
                    _monitor.Pulse();
                }
            }
        }

        private HttpClient CreateHttpClient()
        {
            var handler = new HttpClientHandler();

            handler.SslProtocols = SslProtocols.Tls12;

            if (_certificate != null)
            {
                handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                handler.ClientCertificates.Add(_certificate);
            }

            var client = new HttpClient(handler);
            client.BaseAddress = new Uri(_url);

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
    }
}
