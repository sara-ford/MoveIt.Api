using AutoMapper;
using MoveIt.Core.Models;
using MoveIt.Core.Resources;

namespace MoveIt.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            //CreateMap<Members, MemberResource>().ForMember
            //    (dest => dest.DepartmentName,
            //    opt => opt.MapFrom
            //    (src => src.Department.Name));
            //CreateMap<MemberResource, Members>().ForMember(des => des.Department, op => op.Ignore());

        }

    }
}
