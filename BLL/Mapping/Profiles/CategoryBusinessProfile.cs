using AutoMapper;
using DalDto = BSF.DAL.Abstractions.Dto.CategoryEntityDto;
using Dto = BSF.BLL.Abstractions.Dto.CategoryBusinessDto;

namespace BSF.BLL.Mapping.Profiles
{
    internal sealed class CategoryBusinessProfile : Profile
    {
        public CategoryBusinessProfile()
        {
            CreateMap<Dto, DalDto>()
                .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
                .ForMember(x => x.Name, o => o.MapFrom(m => m.Name))
                .ForMember(x => x.CodePrefixId, o => o.MapFrom(m => m.CodePrefixId))
                .ForMember(x => x.Description, o => o.MapFrom(m => m.Description))
                .ForMember(x => x.ParentId, o => o.MapFrom(m => m.ParentId))
                .ForMember(x => x.UserId, o => o.MapFrom(m => m.UserId))
                .ReverseMap();
        }
    }
}
