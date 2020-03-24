using System.Threading.Tasks;
using Pliance.SDK.Contract;

namespace Pliance.SDK
{
    public interface IPersonPlianceClient
    {
        Task<RegisterPersonResponse> RegisterPerson(RegisterPersonCommand command);
        Task<ArchivePersonResponse> ArchivePerson(ArchivePersonCommand command);
        Task<UnarchivePersonResponse> UnarchivePerson(UnarchivePersonCommand command);
        Task<DeletePersonResponse> DeletePerson(DeletePersonCommand command);
        Task<ClassifyPersonHitResponse> ClassifyPersonHit(ClassifyPersonHitCommand command);
        Task<PersonSearchQueryResult> SearchPerson(PersonSearchQuery query);
        Task<ViewPersonQueryResult> ViewPerson(ViewPersonQuery query);
    }

    public interface ICompanyPlianceClient
    {
        Task<RegisterCompanyResponse> RegisterCompany(RegisterCompanyCommand command);
        Task<DeleteCompanyResponse> DeleteCompany(DeleteCompanyCommand command);
        Task<ArchiveCompanyResponse> ArchiveCompany(ArchiveCompanyCommand command);
        Task<UnarchiveCompanyResponse> UnarchiveCompany(UnarchiveCompanyCommand command);
        Task<CompanySearchQueryResult> SearchCompany(CompanySearchQuery request);
        Task<ViewCompanyQueryResult> ViewCompany(ViewCompanyQuery request);
        Task<ClassifyCompanyHitResponse> ClassifyCompanyHit(ClassifyCompanyHitCommand command);
    }

    public interface IPersonWatchlist
    {
        Task<WatchlistQueryResult> ViewWatchlistPerson(WatchlistQuery query);
        Task<WatchlistQueryResult_v2> ViewWatchlistPerson_v2(WatchlistQuery_v2 query);
    }

    public interface IFeedPlianceClient
    {
        Task<FeedQueryResult> Feed(FeedQuery query);
    }

    public interface ICompanyWatchlist
    {
        Task<WatchlistCompanyQueryResult> ViewWatchlistCompany(WatchlistCompanyQuery query);
    }

    public interface IPlianceClient : IPersonPlianceClient, ICompanyPlianceClient, IPersonWatchlist, IFeedPlianceClient, ICompanyWatchlist
    {
        Task<PingResponse> Ping();
    }
}
