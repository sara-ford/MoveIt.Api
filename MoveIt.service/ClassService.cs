using MoveIt.Core.Models;
using MoveIt.Core.Repository;
using MoveIt.Core.Resources;
using MoveIt.Core.Services;

namespace MoveIt.Service
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public IEnumerable<ClassResource> GetAvailableClassesForMember(int memberId)
        {
            var ClassResource = _classRepository.GetUpcomingClassesWithRegistrations();

            var available = ClassResource
                .Where(c =>
                    c.ClassRegistrations.Count < c.MaxCapacity &&
                    !c.ClassRegistrations.Any(r => r.MemberID.Id == memberId)
                )
                .Select(c => new ClassResource
                {
                    Id = c.Id,
                    ClassName = c.ClassName,
                    StartTime = c.StartTime,
                    Duration = c.Duration,
                    MaxCapacity = c.MaxCapacity,
                    CurrentRegistrations = c.ClassRegistrations.Count
                });

            return available;
        }
    }
}