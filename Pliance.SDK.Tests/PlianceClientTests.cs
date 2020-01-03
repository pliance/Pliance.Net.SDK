using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pliance.Core.Contract;
using Pliance.SDK.Contract;
using Xunit;

namespace Pliance.SDK.Tests
{
    public class PlianceClientTests
    {
        private string _id;
        private PlianceClientFactory _factory;
        private IPlianceClient _client;

        public PlianceClientTests()
        {
            _id = Guid.NewGuid().ToString();
            _factory = CreateFactory();
            _client = _factory.Create("givenname", "sub");
        }

        [Fact]
        public async Task Api_Ping_Success()
        {
            await _client.Ping();
        }

        [Fact]
        public async Task Api_RegisterPerson_Success()
        {
            await CreatePerson();
        }

        [Fact]
        public async Task Api_DeletePerson_Success()
        {
            await CreatePerson();
            var result = await _client.DeletePerson(new DeletePersonCommand
            {
                PersonReferenceId = _id
            });
        }

        [Fact]
        public async Task Api_ArchivePerson_Success()
        {
            await CreatePerson();            
            var result = await _client.ArchivePerson(new ArchivePersonCommand
            {
                PersonReferenceId = _id
            });
        }

        [Fact]
        public async Task Api_ClassifyPerson_Success()
        {
            await CreatePerson();
            var person = await _client.ViewPerson(new ViewPersonQuery
            {
                PersonReferenceId = _id,
            });
            var result = await _client.ClassifyPersonHit(new ClassifyHitCommand
            {
                PersonReferenceId = _id,
                MatchId = person.Data.Hits[0][0].MatchId,
                AliasId = person.Data.Hits[0][0].AliasId,
                Classification = ClassificationType.Positive
            });
        }

        [Fact]
        public async Task Api_SearchPerson_Success()
        {
            var result = await _client.SearchPerson(new PersonSearchQuery());

//            Console.WriteLine(JsonConvert.SerializeObject(result));
        }

        [Fact]
        public async Task Api_WatchlistQuery_v1_Success()
        {
            await CreatePerson();
            await _client.ViewWatchlistPerson(new WatchlistQuery
            {
                Id = "Bogard-13935",
                FirstName = "",
                LastName = "",
            });
        }

        [Fact]
        public async Task Api_WatchlistQuery_v2_Success()
        {
            await CreatePerson();
            await _client.ViewWatchlistPerson_v2(new WatchlistQuery_v2
            {
                MatchId = "Bogard-13935",
                PersonReferenceId = _id,
            });
        }

        private PlianceClientFactory CreateFactory()
        {
            return new PlianceClientFactory(
                secret: "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b",
                issuer: "Demo",
                url: "https://local.pliance.io/",
                certificate: new X509Certificate2("client.pfx")
            );
        }

        private async Task<RegisterPersonResponse> CreatePerson()
        {
            return await _client.RegisterPerson(new RegisterPersonCommand
            {
                PersonReferenceId = _id,
                FirstName = "Ebba-Elisabeth",
                LastName = "Busch",
                Identity = new PersonIdentity("", "se"),
            });
        }
    }
}
