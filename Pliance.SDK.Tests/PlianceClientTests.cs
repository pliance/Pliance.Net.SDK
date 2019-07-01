using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Pliance.SDK.Contract;
using Xunit;

namespace Pliance.SDK.Tests
{
    public class PlianceClientTests
    {
        // [Fact]
        // public async Task Test1()
        // {
        //     var factory = new PlianceClientFactory(
        //         secret: "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b",
        //         company: "adam",
        //         issuer: "Demo",
        //         url: "https://adam.pliance.io/",
        //         certificate: new X509Certificate2("client.pfx")
        //     );

        //     var client = factory.Create("givenname", "sub");

        //     await client.Ping();
        // }

        [Fact]
        public async Task Test2()
        {
            var factory = new PlianceClientFactory(
                secret: "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b",
                company: "adam",
                issuer: "Demo",
                url: "https://adam.pliance.io/",
                certificate: new X509Certificate2("client.pfx")
            );

            var client = factory.Create("givenname", "sub");

            for (var i = 0; i < 20_000; ++i)
            {
                Console.WriteLine(i);
                await client.RegisterPerson(new RegisterPersonCommand()
                {
                    PersonReferenceId = Guid.NewGuid().ToString(),
                    FirstName = "Adam",
                    LastName = "Användare"
                });
            }
        }
    }
}
