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
        public async Task PingCeritficateWithPassword()
        {
            _x509Certificate2 = new X509Certificate2("client-password.pfx", "password");
            _url = "https://local-no-cert.pliance.io/";
            
            var client = CreateClient();
            
            await client.Ping(new PingQuery());
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
        
        [Fact]
        public async Task TestWatchlistPersonV1()
        {
            var person = await CreatePerson();
            var match = person.Data.Hits[0][0];
            var response = await _client.WatchlistPerson(new WatchlistQuery
            {
                Id = match.MatchId,
                FirstName = "Osama",
                LastName = "bin Laden",
            });
            
            Assert.True(response.Success);
        }       
        
        [Fact]
        public async Task TestWatchlistPersonV2()
        {
            var person = await CreatePerson();
            var match = person.Data.Hits[0][0];
            var response = await _client.WatchlistPersonV2(new WatchlistQueryV2
            {
                MatchId = match.MatchId,
                PersonReferenceId = _id,
            });
            
            Assert.True(response.Success);
        }           
        
        //[Fact]
        //public async Task TestFeed()
        //{
        //    var response = await _client.Feed(new FeedQuery());
            
        //    Assert.True(response.Success);
        //}         
        
        [Fact]
        public async Task TestSaveWebhook()
        {
            var response = await _client.SaveWebhook(new WebhookUpdateCommand
            {
                Enabled = true,
                Secret = "secret",
                Url = "https://url",
            });
            
            Assert.True(response.Success);
        } 
        
        [Fact]
        public async Task TestGetWebhook()
        {
            var response = await _client.GetWebhook(new WebhookQuery());
            
            Assert.True(response.Success);
        }         
        
              [Fact]
        public async Task TestRegisterCompany()
        {
            var response = await CreateCompany();
            
            Assert.True(response.Success);
        }
        
        [Fact]
        public async Task TestArchiveCompany()
        {
            await CreateCompany();
            var response = await ArchiveCompany();
            
            Assert.True(response.Success);
        }

        [Fact]
        public async Task TestUnarchiveCompany()
        {
            await CreateCompany();
            await ArchiveCompany();
            var response = await _client.UnarchiveCompany(new UnarchiveCompanyCommand
            {
                CompanyReferenceId = _id,
            });
            
            Assert.True(response.Success);
        }
        
        [Fact]
        public async Task TestDeleteCompany()
        {
            await CreateCompany();
            var response = await _client.DeleteCompany(new DeleteCompanyCommand
            {
                CompanyReferenceId = _id,
            });
            
            Assert.True(response.Success);
        }
        
        [Fact]
        public async Task TestViewCompany()
        {
            await CreateCompany();
            var response = await _client.ViewCompany(new ViewCompanyQuery
            {
                CompanyReferenceId = _id,
            });
            
            Assert.True(response.Success);
        }   
        
        [Fact]
        public async Task TestSearchCompany()
        {
            await CreateCompany();
            var response = await _client.SearchCompany(new CompanySearchQuery
            {
                Query = "Daesong"
            });
            
            Assert.True(response.Success);
        } 
        
        [Fact]
        public async Task TestClassifyCompany()
        {
            var company = await CreateCompany();
            var match = company.Data.Hits[0][0];
            var response = await _client.ClassifyCompanyHit(new ClassifyCompanyHitCommand
            {
                CompanyReferenceId = _id,
                Classification = ClassificationType.FalsePositive,
                AliasId = match.AliasId,
                MatchId = match.MatchId,
            });
            
            Assert.True(response.Success);
        } 
        
        [Fact]
        public async Task TestWatchlistCompany()
        {
            var company = await CreateCompany();
            var match = company.Data.Hits[0][0];
            var response = await _client.WatchlistCompany(new WatchlistCompanyQuery
            {
                MatchId = match.MatchId,
                CompanyReferenceId = _id,
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
        
        private async Task<RegisterCompanyResponse> CreateCompany()
        {
            return await _client.RegisterCompany(new RegisterCompanyCommand
            {
                CompanyReferenceId = _id,
                Name = "Korea Daesong Bank",
            });
        }

        private async Task<ArchivePersonResponse> ArchivePerson()
        {
            return await _client.ArchivePerson(new ArchivePersonCommand
            {
                PersonReferenceId = _id,
            });
        }
        
        private async Task<ArchiveCompanyResponse> ArchiveCompany()
        {
            return await _client.ArchiveCompany(new ArchiveCompanyCommand
            {
                CompanyReferenceId = _id,
            });
        }

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
    }
}
