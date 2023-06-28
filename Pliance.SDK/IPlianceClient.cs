using System.Threading.Tasks;
using Pliance.SDK.Contract;

namespace Pliance.SDK
{
    public interface IPlianceClient
    {
        // @inject: interface		Task<CompanySearchQueryResult> SearchCompany(CompanySearchQuery request);
		Task<ViewCompanyQueryResult> ViewCompany(ViewCompanyQuery request);
		Task<ViewCompanyDataQueryResult> CompanyData(ViewCompanyDataQuery request);
		Task<ListCompanyQueryResult> ListCompanies(ListCompanyQuery request);
		Task<PersonSearchQueryResult> SearchPerson(PersonSearchQuery request);
		Task<ViewPersonQueryResult> ViewPerson(ViewPersonQuery request);
		Task<ListPersonQueryResult> ListPersons(ListPersonQuery request);
		Task<PingResponse> Ping(PingQuery request);
		Task<PersonReportQueryResult> GetPersonReport(PersonReportQuery request);
		Task<GeneralReportQueryResult> GetGeneralReport(GeneralReportQuery request);
		Task<CompanyReportQueryResult> GetCompanyReport(CompanyReportQuery request);
		Task<WatchlistQueryResult> WatchlistPerson(WatchlistQuery request);
		Task<WatchlistQueryResultV2> WatchlistPersonV2(WatchlistQueryV2 request);
		Task<WatchlistCompanyQueryResult> WatchlistCompany(WatchlistCompanyQuery request);
		Task<WebhookQueryResult> GetWebhook(WebhookQuery request);
		Task<WebhookPokeQueryResult> Poke(WebhookPokeQuery query);
		Task<WebhookDeliveryFailuresQueryResult> ListWebhookDeliveryFailures(WebhookDeliveryFailuresQuery query);
		Task<RegisterCompanyV2Response> RegisterCompanyV2(RegisterCompanyV2Command command);
		Task<ArchiveCompanyResponse> ArchiveCompanyV2(ArchiveCompanyCommand command);
		Task<UnarchiveCompanyResponse> UnarchiveCompanyV2(UnarchiveCompanyCommand command);
		Task<DeleteCompanyResponse> DeleteCompanyV2(DeleteCompanyCommand command);
		Task<ClassifyCompanyResponse> ClassifyCompanyV2Match(ClassifyCompanyCommand command);
		Task<ClassifyCompanyLinkResponse> ClassifyCompanyV2Link(ClassifyCompanyLinkCommand command);
		Task<ViewCompanyV2Response> ViewCompanyV2(ViewCompanyQuery query);
		Task<RegisterCompanyResponse> RegisterCompany(RegisterCompanyCommand command);
		Task<ArchiveCompanyResponse> ArchiveCompany(ArchiveCompanyCommand command);
		Task<UnarchiveCompanyResponse> UnarchiveCompany(UnarchiveCompanyCommand command);
		Task<DeleteCompanyResponse> DeleteCompany(DeleteCompanyCommand command);
		Task<ClassifyCompanyHitResponse> ClassifyCompanyHit(ClassifyCompanyHitCommand command);
		Task<RegisterPersonResponse> RegisterPerson(RegisterPersonCommand command);
		Task<ArchivePersonResponse> ArchivePerson(ArchivePersonCommand command);
		Task<UnarchivePersonResponse> UnarchivePerson(UnarchivePersonCommand command);
		Task<DeletePersonResponse> DeletePerson(DeletePersonCommand command);
		Task<ClassifyPersonHitResponse> ClassifyPersonHit(ClassifyPersonHitCommand command);
		Task<WebhookUpdateResponse> SaveWebhook(WebhookUpdateCommand command);
        // @inject: !interface
        IPlianceClient WithRequestId(string requestId);
    }
}

