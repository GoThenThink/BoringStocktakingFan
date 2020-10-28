using AutoMapper;
using Dto = BSF.DAL.Abstractions.Dto.CategoryEntityDto;
using Entity = BSF.DAL.Entities.CategoryEntity;

namespace BSF.DAL.Mapping
{
    internal sealed class CategoryEntityProfile : Profile
    {
        public CategoryEntityProfile()
        {
            CreateMap<Dto, Entity>()
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
