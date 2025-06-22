using MoveIt.Core.Models;
using MoveIt.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace MoveIt.Data.DataRepository
{
    public class ClassRepository : IClassRepository
    {
        private readonly MoveItContext _context;

        public ClassRepository(MoveItContext context)
        {
            _context = context;
        }

        public IEnumerable<Classes> GetUpcomingClassesWithRegistrations()
        {
            return _context.Classes
                .Include(c => c.ClassRegistrations)
                .ThenInclude(r => r.MemberID)
                .Where(c => c.StartTime > DateTime.Now)
                .ToList();
        }
    }
}
