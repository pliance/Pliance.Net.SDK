using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pliance.SDK.Contract;
using Xunit;

namespace Pliance.SDK.Tests
{
    public class PlianceClientTests
    {
        [Fact]
        public async Task Api_Ping_Success()
        {
            var factory = new PlianceClientFactory(
                secret: "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b",
                issuer: "Test",
                url: "https://test.pliance.io/",
                certificate: new X509Certificate2("client.pfx")
            );

            var client = factory.Create("givenname", "sub");

            await client.Ping();
        }

        [Fact]
        public async Task Api_RegisterPerson_Success()
        {
            var factory = new PlianceClientFactory(
                secret: "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b",
                issuer: "Test",
                url: "https://test.pliance.io/",
                certificate: new X509Certificate2("client.pfx")
            );

            var client = factory.Create("givenname", "sub");
            var result = await client.RegisterPerson(new RegisterPersonCommand()
            {
                PersonReferenceId = Guid.NewGuid().ToString(),
                FirstName = "Adam",
                LastName = "Användare"
            });
        }
    }
}
