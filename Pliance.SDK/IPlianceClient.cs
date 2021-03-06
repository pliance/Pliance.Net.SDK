using System.Threading.Tasks;
using Pliance.SDK.Contract;

namespace Pliance.SDK
{
    public interface IPlianceClient
    {
        // @inject: interface
		Task<CompanySearchQueryResult> SearchCompany(CompanySearchQuery request);
		Task<ViewCompanyQueryResult> ViewCompany(ViewCompanyQuery request);
		Task<CompanyGraphBeneficiariesResult> Beneficiaries(CompanyGraphBeneficiariesQuery request);
		Task<FeedQueryResult> Feed(FeedQuery request);
		Task<PersonSearchQueryResult> SearchPerson(PersonSearchQuery request);
		Task<ViewPersonQueryResult> ViewPerson(ViewPersonQuery request);
		Task<PingResponse> Ping(PingQuery request);
		Task<ReportQueryResult> GetReport(ReportQuery request);
		Task<WatchlistQueryResult> WatchlistPerson(WatchlistQuery request);
		Task<WatchlistQueryResult_v2> WatchlistPerson_v2(WatchlistQuery_v2 request);
		Task<WatchlistCompanyQueryResult> WatchlistCompany(WatchlistCompanyQuery request);
		Task<WebhookQueryResult> GetWebhook(WebhookQuery request);
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
    }
}

