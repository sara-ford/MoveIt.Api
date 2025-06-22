using MoveIt.Core.Models;

namespace MoveIt.Core.Services
{
    public interface IMemberService
    {
        Task<Members?> GetMemberById(int id);

        Task<int?> AddMember(Members member);


    }
}
