using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pliance.SDK.Contract;
using Xunit;

namespace Pliance.SDK.Tests
{
    public class PlianceClientTests
    {
        private readonly string _id;
        private readonly IPlianceClient _client;
        private X509Certificate2 _x509Certificate2;
        private string _url;

        public PlianceClientTests()
        {
            _id = Guid.NewGuid().ToString();
            _x509Certificate2 = new X509Certificate2("client.pfx", "");
            _url = "https://local.pliance.io/";
            _client = CreateClient();
        }

        [Fact]
        public async Task BadRequest()
        {
            await Assert.ThrowsAsync<Pliance.SDK.Exceptions.ApiException>(async () =>
            {
                await _client.ViewPerson(new ViewPersonQuery
                {
                    PersonReferenceId = _id,
                });
            });
        }
        
        [Fact]
        public async Task Ping()
        {
            await _client.Ping(new PingQuery());
        }
        
        [Fact]
        public async Task PingNoCert()
        {
            _x509Certificate2 = null;
            _url = "https://local-no-cert.pliance.io/";
            
            var client = CreateClient();
            
            await client.Ping(new PingQuery());
        }

        [Fact]
        public async Task TestRegisterPerson()
        {
            var response = await CreatePerson();
            
            Assert.True(response.Success);
        }
        
        [Fact]
        public async Task TestArchivePerson()
        {
            await CreatePerson();
            var response = await ArchivePerson();
            
            Assert.True(response.Success);
        }

        [Fact]
        public async Task TestUnarchivePerson()
        {
            await CreatePerson();
            await ArchivePerson();
            var response = await _client.UnarchivePerson(new UnarchivePersonCommand
            {
                PersonReferenceId = _id,
            });
            
            Assert.True(response.Success);
        }
        
        [Fact]
        public async Task TestDeletePerson()
        {
            await CreatePerson();
            var response = await _client.DeletePerson(new DeletePersonCommand
            {
                PersonReferenceId = _id,
            });
            
            Assert.True(response.Success);
        }
        
        [Fact]
        public async Task TestViewPerson()
        {
            await CreatePerson();
            var response = await _client.ViewPerson(new ViewPersonQuery
            {
                PersonReferenceId = _id,
            });
            
            Assert.True(response.Success);
        }   
        
        [Fact]
        public async Task TestSearchPerson()
        {
            await CreatePerson();
            var response = await _client.SearchPerson(new PersonSearchQuery
            {
                Query = "Osama"
            });
            
            Assert.True(response.Success);
        } 
        
        [Fact]
        public async Task TesClassifyPerson()
        {
            var person = await CreatePerson();
            var match = person.Data.Hits[0][0];
            var response = await _client.ClassifyPersonHit(new ClassifyPersonHitCommand
            {
                PersonReferenceId = _id,
                Classification = ClassificationType.FalsePositive,
                AliasId = match.AliasId,
                MatchId = match.MatchId,
            });
            
            Assert.True(response.Success);
        } 
        
        private async Task<RegisterPersonResponse> CreatePerson()
        {
            return await _client.RegisterPerson(new RegisterPersonCommand
            {
                PersonReferenceId = _id,
                FirstName = "Osama",
                LastName = "bin Laden",
            });
        }

        private async Task<ArchivePersonResponse> ArchivePerson()
        {
            return await _client.ArchivePerson(new ArchivePersonCommand
            {
                PersonReferenceId = _id,
            });
        }

        //         public PlianceClientTests()
        //         {
        //             _id = Guid.NewGuid().ToString();
        //             _factory = CreateFactory();
        //             _client = _factory.Create("givenname", "sub");
        //         }

        //         [Fact]
        //         public async Task Api_Ping_Success()
        //         {
        //             await _client.Ping(new PingQuery());
        //         }

        //         [Fact]
        //         public async Task Api_RegisterPerson_Success()
        //         {
        //             var person = await CreatePerson();
        //         }

        //         [Fact]
        //         public async Task Api_Feed_Success()
        //         {
        //             await _client.Feed(new FeedQuery());
        //         }

        //         [Fact]
        //         public async Task Api_DeletePerson_Success()
        //         {
        //             await CreatePerson();
        //             var result = await _client.DeletePerson(new DeletePersonCommand
        //             {
        //                 PersonReferenceId = _id
        //             });
        //         }

        //         [Fact]
        //         public async Task Api_ArchivePerson_Success()
        //         {
        //             await CreatePerson();            
        //             var result = await _client.ArchivePerson(new ArchivePersonCommand
        //             {
        //                 PersonReferenceId = _id
        //             });
        //         }

        //         [Fact]
        //         public async Task Api_ClassifyPerson_Success()
        //         {
        //             await CreatePerson();
        //             var person = await _client.ViewPerson(new ViewPersonQuery
        //             {
        //                 PersonReferenceId = _id,
        //             });
        //             var result = await _client.ClassifyPersonHit(new ClassifyPersonHitCommand
        //             {
        //                 PersonReferenceId = _id,
        //                 MatchId = person.Data.Hits[0][0].MatchId,
        //                 AliasId = person.Data.Hits[0][0].AliasId,
        //                 Classification = ClassificationType.Match,
        //             });
        //         }

        //         [Fact]
        //         public async Task Api_SearchPerson_Success()
        //         {
        //             var result = await _client.SearchPerson(new PersonSearchQuery());

        // //            Console.WriteLine(JsonConvert.SerializeObject(result));
        //         }

        //         [Fact]
        //         public async Task Api_WatchlistQuery_v1_Success()
        //         {
        //             await CreatePerson();
        //             await _client.WatchlistPerson(new WatchlistQuery
        //             {
        //                 Id = "Bogard-13935",
        //                 FirstName = "",
        //                 LastName = "",
        //             });
        //         }

        //         [Fact]
        //         public async Task Api_WatchlistQuery_v2_Success()
        //         {
        //             await CreatePerson();
        //             await _client.WatchlistPersonV2(new WatchlistQueryV2
        //             {
        //                 MatchId = "Bogard-13935",
        //                 PersonReferenceId = _id,
        //             });
        //         }

        private IPlianceClient CreateClient()
        {
            var factory = CreateFactory();
            var client = factory.Create("Adam Furtenbach", "1337");

            return client;
        }

        private PlianceClientFactory CreateFactory()
        {
            return new PlianceClientFactory(
                secret: "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b",
                issuer: "Demo",
                url: _url,
                certificate: _x509Certificate2
            );
        }

        //         private async Task<RegisterPersonResponse> CreatePerson()
        //         {
        //             return await _client.RegisterPerson(new RegisterPersonCommand
        //             {
        //                 PersonReferenceId = _id,
        //                 FirstName = "Ebba-Elisabeth",
        //                 LastName = "Busch",
        //                 Identity = new PersonIdentity
        //                 {
        //                     Country = "se",
        //                     Identity = "",
        //                 },
        //             });
        //         }
    }
}
