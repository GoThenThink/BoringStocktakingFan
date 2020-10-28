using AutoMapper;
using Dto = BSF.DAL.Abstractions.Dto.CodePrefixEntityDto;
using Entity = BSF.DAL.Entities.CodePrefixEntity;

namespace BSF.DAL.Mapping
{
    internal sealed class CodePrefixEntityProfile : Profile
    {
        public CodePrefixEntityProfile()
        {
            CreateMap<Dto, Entity>()
                .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
                .ForMember(x => x.Code, o => o.MapFrom(m => m.Code))
                .ForMember(x => x.UserId, o => o.MapFrom(m => m.UserId))
                .ReverseMap();
        }
    }
}
