using System;
using System.Net.Http;
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
        private readonly string _tenant;
        private string _requestId;

        public PlianceClient(PlianceClientFactory factory, string givenName, string subject, string tenant)
        {
            _subject = subject;
            _givenName = givenName;
            _tenant = tenant;
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        // @inject: methods
		public async Task<ArchiveCompanyResponse> ArchiveCompany(ArchiveCompanyCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecutePost<ArchiveCompanyResponse>("api/CompanyCommand/Archive", command);
		}

		public async Task<ArchiveCompanyResponse> ArchiveCompanyV2(ArchiveCompanyCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecutePost<ArchiveCompanyResponse>("api/CompanyV2Command/Archive", command);
		}

		public async Task<ArchivePersonResponse> ArchivePerson(ArchivePersonCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecutePost<ArchivePersonResponse>("api/PersonCommand/Archive", command);
		}

		public async Task<ClassifyCompanyHitResponse> ClassifyCompanyHit(ClassifyCompanyHitCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecutePost<ClassifyCompanyHitResponse>("api/CompanyCommand/Classify", command);
		}

		public async Task<ClassifyCompanyLinkResponse> ClassifyCompanyV2Link(ClassifyCompanyLinkCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecutePost<ClassifyCompanyLinkResponse>("api/CompanyV2Command/ClassifyLink", command);
		}

		public async Task<ClassifyCompanyResponse> ClassifyCompanyV2Match(ClassifyCompanyCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecutePost<ClassifyCompanyResponse>("api/CompanyV2Command/Classify", command);
		}

		public async Task<ClassifyPersonHitResponse> ClassifyPersonHit(ClassifyPersonHitCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecutePost<ClassifyPersonHitResponse>("api/PersonCommand/Classify", command);
		}

		public async Task<ViewCompanyDataQueryResult> CompanyData(ViewCompanyDataQuery request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<ViewCompanyDataQueryResult>("api/CompanyQuery/CompanyData" + request.UrlEncoded());
		}

		public async Task<DeleteCompanyResponse> DeleteCompany(DeleteCompanyCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecuteDelete<DeleteCompanyResponse>("api/CompanyCommand" + command.UrlEncoded());
		}

		public async Task<DeleteCompanyResponse> DeleteCompanyV2(DeleteCompanyCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecuteDelete<DeleteCompanyResponse>("api/CompanyV2Command" + command.UrlEncoded());
		}

		public async Task<DeletePersonResponse> DeletePerson(DeletePersonCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecuteDelete<DeletePersonResponse>("api/PersonCommand" + command.UrlEncoded());
		}

		public async Task<CompanyReportQueryResult> GetCompanyReport(CompanyReportQuery request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<CompanyReportQueryResult>("api/ReportQuery/CompanyReport" + request.UrlEncoded());
		}

		public async Task<GeneralReportQueryResult> GetGeneralReport(GeneralReportQuery request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<GeneralReportQueryResult>("api/ReportQuery/GeneralReport" + request.UrlEncoded());
		}

		public async Task<PersonReportQueryResult> GetPersonReport(PersonReportQuery request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<PersonReportQueryResult>("api/ReportQuery/PersonReport" + request.UrlEncoded());
		}

		public async Task<WebhookQueryResult> GetWebhook(WebhookQuery request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<WebhookQueryResult>("api/WebhookQuery" + request.UrlEncoded());
		}

		public async Task<ListCompanyQueryResult> ListCompanies(ListCompanyQuery request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<ListCompanyQueryResult>("api/CompanyQuery/List" + request.UrlEncoded());
		}

		public async Task<ListPersonQueryResult> ListPersons(ListPersonQuery request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<ListPersonQueryResult>("api/PersonQuery/List" + request.UrlEncoded());
		}

		public async Task<WebhookDeliveryFailuresQueryResult> ListWebhookDeliveryFailures(WebhookDeliveryFailuresQuery query)
		{
			if (query is null)
			{
				throw new ArgumentNullException(nameof(query));
			}

			return await ExecuteGet<WebhookDeliveryFailuresQueryResult>("api/WebhookQuery/DeliveryFailures" + query.UrlEncoded());
		}

		public async Task<PingResponse> Ping(PingQuery request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<PingResponse>("api/Ping" + request.UrlEncoded());
		}

		public async Task<WebhookPokeQueryResult> Poke(WebhookPokeQuery query)
		{
			if (query is null)
			{
				throw new ArgumentNullException(nameof(query));
			}

			return await ExecutePost<WebhookPokeQueryResult>("api/WebhookQuery/Poke", query);
		}

		public async Task<RegisterCompanyResponse> RegisterCompany(RegisterCompanyCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecutePut<RegisterCompanyResponse>("api/CompanyCommand", command);
		}

		public async Task<RegisterCompanyV2Response> RegisterCompanyV2(RegisterCompanyV2Command command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecutePut<RegisterCompanyV2Response>("api/CompanyV2Command", command);
		}

		public async Task<RegisterPersonResponse> RegisterPerson(RegisterPersonCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecutePut<RegisterPersonResponse>("api/PersonCommand", command);
		}

		public async Task<WebhookUpdateResponse> SaveWebhook(WebhookUpdateCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecutePut<WebhookUpdateResponse>("api/WebhookCommand", command);
		}

		public async Task<CompanySearchQueryResult> SearchCompany(CompanySearchQuery request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<CompanySearchQueryResult>("api/CompanyQuery/Search" + request.UrlEncoded());
		}

		public async Task<SearchCompanyV2Response> SearchCompany(SearchCompanyQuery request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<SearchCompanyV2Response>("api/CompanyV2Query/Search" + request.UrlEncoded());
		}

		public async Task<PersonSearchQueryResult> SearchPerson(PersonSearchQuery request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<PersonSearchQueryResult>("api/PersonQuery/Search" + request.UrlEncoded());
		}

		public async Task<UnarchiveCompanyResponse> UnarchiveCompany(UnarchiveCompanyCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecutePost<UnarchiveCompanyResponse>("api/CompanyCommand/Unarchive", command);
		}

		public async Task<UnarchiveCompanyResponse> UnarchiveCompanyV2(UnarchiveCompanyCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecutePost<UnarchiveCompanyResponse>("api/CompanyV2Command/Unarchive", command);
		}

		public async Task<UnarchivePersonResponse> UnarchivePerson(UnarchivePersonCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecutePost<UnarchivePersonResponse>("api/PersonCommand/Unarchive", command);
		}

		public async Task<ViewCompanyQueryResult> ViewCompany(ViewCompanyQuery request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<ViewCompanyQueryResult>("api/CompanyQuery" + request.UrlEncoded());
		}

		public async Task<ViewCompanyV2Response> ViewCompanyV2(ViewCompanyQuery request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<ViewCompanyV2Response>("api/CompanyV2Query" + request.UrlEncoded());
		}

		public async Task<ViewPersonQueryResult> ViewPerson(ViewPersonQuery request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<ViewPersonQueryResult>("api/PersonQuery" + request.UrlEncoded());
		}

		public async Task<WatchlistCompanyQueryResult> WatchlistCompany(WatchlistCompanyQuery request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<WatchlistCompanyQueryResult>("api/WatchlistQuery/Company" + request.UrlEncoded());
		}

		public async Task<WatchlistQueryResult> WatchlistPerson(WatchlistQuery request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<WatchlistQueryResult>("api/WatchlistQuery" + request.UrlEncoded());
		}

		public async Task<WatchlistQueryResultV2> WatchlistPersonV2(WatchlistQueryV2 request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<WatchlistQueryResultV2>("api/WatchlistQuery/v2" + request.UrlEncoded());
		}

        // @inject: !methods

        public IPlianceClient WithRequestId(string requestId)
        {
	        _requestId = requestId;
	        return this;
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

                if (!string.IsNullOrEmpty(_requestId))
                {
	                client.DefaultRequestHeaders.Remove("X-Request-Id");
	                client.DefaultRequestHeaders.Add("X-Request-Id", _requestId);
                }
                
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
                
                if (!string.IsNullOrEmpty(_requestId))
                {
	                client.DefaultRequestHeaders.Remove("X-Request-Id");
	                client.DefaultRequestHeaders.Add("X-Request-Id", _requestId);
                }                
                
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
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(responseString);
            
            if (!response.IsSuccessStatusCode)
            {
	            throw new ApiException(result.Message);
            }            

            if (!result.Success)
            {
                throw new ApiException(result.Message);
            }

            return result;
        }
    }
}
