using System.Threading.Tasks;
using Pliance.SDK.Contract;

namespace Pliance.SDK
{
    public interface IPlianceClient
    {
        Task<RegisterPersonResponse> RegisterPerson(RegisterPersonCommand command);
        Task<ArchivePersonResponse> ArchivePerson(ArchivePersonCommand command);
        Task<UnarchivePersonResponse> UnachivePerson(UnarchivePersonCommand command);
        Task<DeletePersonResponse> DeletePerson(DeletePersonCommand command);
        Task<ClassifyHitResponse> ClassifyPersonHit(ClassifyHitCommand command);
        Task<PersonSearchQueryResult> SearchPerson(PersonSearchQuery query);
        Task<ViewPersonQueryResult> ViewPerson(ViewPersonQuery query);
        Task<PingResponse> Ping();
        Task<RegisterCompanyResponse> RegisterCompany(RegisterCompanyCommand command);
        Task<DeleteCompanyResponse> DeleteCompany(DeleteCompanyCommand command);
        Task<ArchiveCompanyResponse> ArchiveCompany(ArchiveCompanyCommand command);
        Task<CompanySearchQueryResult> SearchCompany(CompanySearchQuery request);
        Task<ViewCompanyQueryResult> ViewCompany(ViewCompanyQuery request);        
    }
}
