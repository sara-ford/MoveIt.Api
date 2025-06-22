using MoveIt.Core.Models;

namespace MoveIt.Core.Repository
{
    public interface IClassRepository
    {
        IEnumerable<Classes> GetUpcomingClassesWithRegistrations();
    }

}
