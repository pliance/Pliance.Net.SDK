using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pliance.SDK.Contract;
using Pliance.SDK.Exceptions;
using ArgumentNullException = Pliance.SDK.Exceptions.ArgumentNullException;

namespace Pliance.SDK
{
    public class PlianceClient : IPlianceClient
    {
        private readonly PlianceClientFactory _factory;
        private readonly string _givenName;
        private readonly string _subject;

        public PlianceClient(PlianceClientFactory factory, string givenName, string subject)
        {
            _subject = subject;
            _givenName = givenName;
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public async Task<RegisterPersonResponse> RegisterPerson(RegisterPersonCommand command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            return await ExecutePut<RegisterPersonResponse>("api/PersonCommand", command);
        }

        public async Task<ArchivePersonResponse> ArchivePerson(ArchivePersonCommand command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            return await ExecutePost<ArchivePersonResponse>("api/PersonCommand/Archive", command);
        }

        public async Task<UnarchivePersonResponse> UnarchivePerson(UnarchivePersonCommand command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            
            return await ExecutePost<UnarchivePersonResponse>("api/PersonCommand/Unarchive", command);
        }

        public async Task<DeletePersonResponse> DeletePerson(DeletePersonCommand command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            
            return await ExecuteDelete<DeletePersonResponse>("api/PersonCommand" + command.UrlEncoded());
        }

        public async Task<ClassifyPersonHitResponse> ClassifyPersonHit(ClassifyPersonHitCommand command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            return await ExecutePost<ClassifyPersonHitResponse>("api/PersonCommand/Classify", command);
        }

        public async Task<PingResponse> Ping()
        {
            return await ExecuteGet<PingResponse>("api/Ping");
        }

        public async Task<FeedQueryResult> Feed(FeedQuery query)
        {
            if (query is null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return await ExecuteGet<FeedQueryResult>("api/FeedQuery/" + query.UrlEncoded());
        }

        public async Task<PersonSearchQueryResult> SearchPerson(PersonSearchQuery query)
        {
            if (query is null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return await ExecuteGet<PersonSearchQueryResult>("api/PersonQuery/Search/" + query.UrlEncoded());
        }

        public async Task<ViewPersonQueryResult> ViewPerson(ViewPersonQuery query)
        {
            if (query is null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            
            return await ExecuteGet<ViewPersonQueryResult>($"api/PersonQuery/" + query.UrlEncoded());
        }

        public async Task<RegisterCompanyResponse> RegisterCompany(RegisterCompanyCommand command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            return await ExecutePut<RegisterCompanyResponse>("api/CompanyCommand", command);
        }

        public async Task<DeleteCompanyResponse> DeleteCompany(DeleteCompanyCommand command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            return await ExecuteDelete<DeleteCompanyResponse>("api/CompanyCommand" + command.UrlEncoded());
        }

        public async Task<ArchiveCompanyResponse> ArchiveCompany(ArchiveCompanyCommand command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            return await ExecutePost<ArchiveCompanyResponse>("api/CompanyCommand/Archive", command);
        }

        public async Task<UnarchiveCompanyResponse> UnarchiveCompany(UnarchiveCompanyCommand command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            
            return await ExecutePost<UnarchiveCompanyResponse>("api/CompanyCommand/Unarchive", command);
        }

        public async Task<CompanySearchQueryResult> SearchCompany(CompanySearchQuery query)
        {
            if (query is null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return await ExecuteGet<CompanySearchQueryResult>("api/CompanyQuery/Search/" + query.UrlEncoded());
        }

        public async Task<ViewCompanyQueryResult> ViewCompany(ViewCompanyQuery query)
        {
            if (query is null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return await ExecuteGet<ViewCompanyQueryResult>($"api/CompanyQuery/" + query.UrlEncoded());
        }

        public async Task<WatchlistQueryResult> ViewWatchlistPerson(WatchlistQuery query)
        {
            if (query is null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            
            return await ExecuteGet<WatchlistQueryResult>($"api/WatchlistQuery/" + query.UrlEncoded());
        }

        public async Task<WatchlistQueryResult_v2> ViewWatchlistPerson_v2(WatchlistQuery_v2 query)
        {
            if (query is null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            
            return await ExecuteGet<WatchlistQueryResult_v2>($"api/WatchlistQuery/v2/" + query.UrlEncoded());
        }

        public async Task<ClassifyCompanyHitResponse> ClassifyCompanyHit(ClassifyCompanyHitCommand command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            return await ExecutePost<ClassifyCompanyHitResponse>("api/CompanyCommand/Classify", command);
        }

        public async Task<WatchlistCompanyQueryResult> ViewWatchlistCompany(WatchlistCompanyQuery query)
        {
            if (query is null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            
            return await ExecuteGet<WatchlistCompanyQueryResult>($"api/WatchlistQuery/Company/" + query.UrlEncoded());
        }

        private async Task<T> ExecuteGet<T>(string path)
            where T : Response
        {
            Func<HttpClient, Task<T>> action = async (client) =>
            {
                var response = await client.GetAsync(path);

                return await HandleResponse<T>(response);
            };
            
            return await _factory.Execute<T>(action, _givenName, _subject);
        }

        private async Task<T> ExecutePost<T>(string path, object input)
            where T : Response
        {
            Func<HttpClient, Task<T>> action = async (client) =>
            {
                var json = JsonConvert.SerializeObject(input);
                var content = new StringContent(json, Encoding.UTF8, "application/json");                
                var response = await client.PostAsync(path, content);

                return await HandleResponse<T>(response);
            };

            
            return await _factory.Execute<T>(action, _givenName, _subject);
        }

        private async Task<T> ExecutePut<T>(string path, object input)
            where T : Response
        {
            Func<HttpClient, Task<T>> action = async (client) =>
            {
                var json = JsonConvert.SerializeObject(input);
                var content = new StringContent(json, Encoding.UTF8, "application/json");                
                var response = await client.PutAsync(path, content);

                return await HandleResponse<T>(response);
            };
            
            return await _factory.Execute<T>(action, _givenName, _subject);
        }

        private async Task<T> ExecuteDelete<T>(string path)
            where T : Response
        {
            Func<HttpClient, Task<T>> action = async (client) =>
            {
                var response = await client.DeleteAsync(path);

                return await HandleResponse<T>(response);
            };
            
            return await _factory.Execute<T>(action, _givenName, _subject);
        }

        private async Task<T> HandleResponse<T>(HttpResponseMessage response) where T : Response
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new ApiException(response.ReasonPhrase);
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(responseString);

            if (!result.Success)
            {
                throw new ApiException(result.Message);
            }

            return result;
        }
    }
}
