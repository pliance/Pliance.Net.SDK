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
        private string _id;

        public PlianceClientTests()
        {
            _id = Guid.NewGuid().ToString();
        }

        [Fact]
        public async Task Api_Ping_Success()
        {
            var factory = CreateFactory();
            var client = factory.Create("givenname", "sub");

            await client.Ping();
        }

        [Fact]
        public async Task Api_RegisterPerson_Success()
        {
            var factory = CreateFactory();
            var client = factory.Create("givenname", "sub");
            var result = await client.RegisterPerson(new RegisterPersonCommand()
            {
                PersonReferenceId = _id,
                FirstName = "Adam",
                LastName = "Användare"
            });
        }

        // [Fact]
        // public async Task Api_DeletePerson_Success()
        // {
        //     var factory = CreateFactory();
        //     var client = factory.Create("givenname", "sub");
        //     var result = await client.DeletePerson(new DeletePersonCommand
        //     {
        //         PersonReferenceId = "reference-id"
        //     });
        // }      

        [Fact]
        public async Task Api_ArchivePerson_Success()
        {
            var factory = CreateFactory();
            var client = factory.Create("givenname", "sub");
            await client.RegisterPerson(new RegisterPersonCommand()
            {
                PersonReferenceId = _id,
                FirstName = "Adam",
                LastName = "Användare"
            });            
            var result = await client.ArchivePerson(new ArchivePersonCommand
            {
                PersonReferenceId = _id
            });
        }        

        // [Fact]
        // public async Task Api_ClassifyPerson_Success()
        // {
        //     var factory = CreateFactory();
        //     var client = factory.Create("givenname", "sub");
        //     var result = await client.ClassifyPersonHit(new ClassifyHitCommand
        //     {
        //         PersonReferenceId = "reference-id",
        //         MatchId = "matchId",
        //         AliasId ="aliasId",
        //         Classification = ClassificationType.Positive
        //     });
        // }    

        [Fact]
        public async Task Api_SearchPerson_Success()
        {
            var factory = CreateFactory();
            var client = factory.Create("givenname", "sub");
            var result = await client.SearchPerson(new PersonSearchQuery
            {
            });

            Console.WriteLine(JsonConvert.SerializeObject(result));
        }                     

        private PlianceClientFactory CreateFactory()
        {
            return new PlianceClientFactory(
                secret: "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b",
                issuer: "Demo",
                url: "https://secure.pliance.io/",
                certificate: new X509Certificate2("client.pfx")
            );
        }
    }
}
