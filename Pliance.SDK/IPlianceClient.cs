using System.Threading.Tasks;
using Pliance.Core.Contract;
using Pliance.SDK.Contract;

namespace Pliance.SDK
{
    public interface IPlianceClient
    {
        Task<RegisterPersonResponse> RegisterPerson(RegisterPersonCommand command);
        Task<ArchivePersonResponse> ArchivePerson(ArchivePersonCommand command);
        Task<UnarchivePersonResponse> UnarchivePerson(UnarchivePersonCommand command);
        Task<DeletePersonResponse> DeletePerson(DeletePersonCommand command);
        Task<ClassifyHitResponse> ClassifyPersonHit(ClassifyHitCommand command);
        Task<PersonSearchQueryResult> SearchPerson(PersonSearchQuery query);
        Task<ViewPersonQueryResult> ViewPerson(ViewPersonQuery query);
        Task<PingResponse> Ping();
        Task<RegisterCompanyResponse> RegisterCompany(RegisterCompanyCommand command);
        Task<DeleteCompanyResponse> DeleteCompany(DeleteCompanyCommand command);
        Task<ArchiveCompanyResponse> ArchiveCompany(ArchiveCompanyCommand command);
        Task<UnarchiveCompanyResponse> UnarchiveCompany(UnarchiveCompanyCommand command);
        Task<CompanySearchQueryResult> SearchCompany(CompanySearchQuery request);
        Task<ViewCompanyQueryResult> ViewCompany(ViewCompanyQuery request);
        Task<WatchlistQueryResult> ViewWatchlistPerson(WatchlistQuery query);
        Task<WatchlistQueryResult_v2> ViewWatchlistPerson_v2(WatchlistQuery_v2 query);
    }
}
