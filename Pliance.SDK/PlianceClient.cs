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

        // @inject: methods
		public async Task<ArchiveCompanyResponse> ArchiveCompany(ArchiveCompanyCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecutePost<ArchiveCompanyResponse>("api/CompanyCommand/Archive", command);
		}

		public async Task<ArchivePersonResponse> ArchivePerson(ArchivePersonCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecutePost<ArchivePersonResponse>("api/PersonCommand/Archive", command);
		}

		public async Task<CompanyGraphBeneficiariesResult> Beneficiaries(CompanyGraphBeneficiariesQuery request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<CompanyGraphBeneficiariesResult>("api/CompanyQuery/Graph/Beneficiaries" + request.UrlEncoded());
		}

		public async Task<ClassifyCompanyHitResponse> ClassifyCompanyHit(ClassifyCompanyHitCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecutePost<ClassifyCompanyHitResponse>("api/CompanyCommand/Classify", command);
		}

		public async Task<ClassifyPersonHitResponse> ClassifyPersonHit(ClassifyPersonHitCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecutePost<ClassifyPersonHitResponse>("api/PersonCommand/Classify", command);
		}

		public async Task<DeleteCompanyResponse> DeleteCompany(DeleteCompanyCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecuteDelete<DeleteCompanyResponse>("api/CompanyCommand/" + command.UrlEncoded());
		}

		public async Task<DeletePersonResponse> DeletePerson(DeletePersonCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecuteDelete<DeletePersonResponse>("api/PersonCommand/" + command.UrlEncoded());
		}

		public async Task<FeedQueryResult> Feed(FeedQuery request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<FeedQueryResult>("api/FeedQuery/" + request.UrlEncoded());
		}

		public async Task<ReportQueryResult> GetReport(ReportQuery request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<ReportQueryResult>("api/ReportQuery/" + request.UrlEncoded());
		}

		public async Task<WebhookQueryResult> GetWebhook(WebhookQuery request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<WebhookQueryResult>("api/WebhookQuery/" + request.UrlEncoded());
		}

		public async Task<PingResponse> Ping(PingQuery request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<PingResponse>("api/Ping/" + request.UrlEncoded());
		}

		public async Task<RegisterCompanyResponse> RegisterCompany(RegisterCompanyCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecutePut<RegisterCompanyResponse>("api/CompanyCommand/", command);
		}

		public async Task<RegisterPersonResponse> RegisterPerson(RegisterPersonCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecutePut<RegisterPersonResponse>("api/PersonCommand/", command);
		}

		public async Task<WebhookUpdateResponse> SaveWebhook(WebhookUpdateCommand command)
		{
			if (command is null)
			{
				throw new ArgumentNullException(nameof(command));
			}

			return await ExecutePut<WebhookUpdateResponse>("api/WebhookCommand/", command);
		}

		public async Task<CompanySearchQueryResult> SearchCompany(CompanySearchQuery request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<CompanySearchQueryResult>("api/CompanyQuery/Search" + request.UrlEncoded());
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

			return await ExecuteGet<ViewCompanyQueryResult>("api/CompanyQuery/" + request.UrlEncoded());
		}

		public async Task<ViewPersonQueryResult> ViewPerson(ViewPersonQuery request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<ViewPersonQueryResult>("api/PersonQuery/" + request.UrlEncoded());
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

			return await ExecuteGet<WatchlistQueryResult>("api/WatchlistQuery/" + request.UrlEncoded());
		}

		public async Task<WatchlistQueryResult_v2> WatchlistPerson_v2(WatchlistQuery_v2 request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			return await ExecuteGet<WatchlistQueryResult_v2>("api/WatchlistQuery/v2" + request.UrlEncoded());
		}

        // @inject: !methods

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
