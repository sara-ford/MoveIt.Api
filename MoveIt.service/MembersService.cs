using MoveIt.Core.Models;
using MoveIt.Core.Repository;
using MoveIt.Core.Services;

namespace MoveIt.Service
{
    public class MembersService : IMemberService
    {
        private readonly IDataRepository _dataRepository;

        public MembersService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<Members?> GetMemberById(int id)
        {
            return await _dataRepository.GetMemberById(id);
        }

        public async Task<int?> AddMember(Members member)
        {
            return await _dataRepository.AddMember(member);
        }

    }
}