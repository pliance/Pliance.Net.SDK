using System.Threading.Tasks;
using Pliance.SDK.Contract;

namespace Pliance.SDK
{
    public interface IPlianceClient
    {
        // @inject: interface
		Task<CompanySearchQueryResult> SearchCompany(CompanySearchQuery query);
		Task<ViewCompanyQueryResult> ViewCompany(ViewCompanyQuery query);
		Task<CompanyGraphBeneficiariesResult> Beneficiaries(CompanyGraphBeneficiariesQuery query);
		Task<FeedQueryResult> Feed(FeedQuery query);
		Task<PersonSearchQueryResult> SearchPerson(PersonSearchQuery query);
		Task<ViewPersonQueryResult> ViewPerson(ViewPersonQuery query);
		Task<PingResponse> Ping(PingQuery query);
		Task<ReportQueryResult> GetReport(ReportQuery query);
		Task<WatchlistQueryResult> WatchlistPerson(WatchlistQuery query);
		Task<WatchlistQueryResult_v2> WatchlistPerson_v2(WatchlistQuery_v2 query);
		Task<WatchlistCompanyQueryResult> WatchlistCompany(WatchlistCompanyQuery query);
		Task<WebhookQueryResult> GetWebhook(WebhookQuery query);
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

