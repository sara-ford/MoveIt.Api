using MoveIt.Core.Models;

namespace MoveIt.Core.Repository
{
    public partial interface IDataRepository
    {
        Task<Members?> GetMemberById(int id);

        Task<int> AddMember(Members Member);

        Task<int> UpdateMember(Members Member);

        Task<int> DeleteMember(int MemberId);
    }
}
