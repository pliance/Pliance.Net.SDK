using System.Threading.Tasks;
using Pliance.SDK.Contract;

namespace Pliance.SDK
{
    public interface IPlianceClient
    {
        Task<RegisterPersonResponse> RegisterPerson(RegisterPersonCommand command);
        Task<ArchivePersonResponse> ArchivePerson(ArchivePersonCommand command);
        Task<DeletePersonResponse> DeletePerson(DeletePersonCommand command);
        Task<ClassifyHitResponse> ClassifyPersonHit(ClassifyHitCommand command);
        Task Ping();
    }
}
