using MoveIt.Core.Models;
using MoveIt.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace MoveIt.Data.DataRepository
{
    public partial class DataRepository : IDataRepository
    {
        private readonly MoveItContext _dbContext;

        public DataRepository(MoveItContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Members?> GetMemberById(int id)
        {
            return await _dbContext.Members.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> AddMember(Members Member)
        {
            _dbContext.Members.Add(Member);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateMember(Members Member)
        {
            var entity = await _dbContext.Members.Where(x => x.Id == Member.Id).FirstAsync();
            _dbContext.Entry(entity).CurrentValues.SetValues(Member);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteMember(int MemberId)
        {
            var entity = await _dbContext.Members.Where(x => x.Id == MemberId).FirstAsync();
            //entity.IsActive = false;
            return await _dbContext.SaveChangesAsync();
        }

    }
}
