using MoveIt.Core.Models;
using MoveIt.Core.Resources;

namespace MoveIt.Core.Services
{
    public interface IClassService
    {
        IEnumerable<ClassResource> GetAvailableClassesForMember(int memberId);
    }

}
