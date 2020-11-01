using AutoMapper;
using DalDto = BSF.DAL.Abstractions.Dto.CodePrefixEntityDto;
using Dto = BSF.BLL.Abstractions.Dto.CodePrefixBusinessDto;

namespace BSF.BLL.Mapping.Profiles
{
    internal sealed class CodePrefixBusinessProfile : Profile
    {
        public CodePrefixBusinessProfile()
        {
            CreateMap<Dto, DalDto>()
                .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
                .ForMember(x => x.Code, o => o.MapFrom(m => m.Code))
                .ForMember(x => x.UserId, o => o.MapFrom(m => m.UserId))
                .ReverseMap();
        }
    }
}
