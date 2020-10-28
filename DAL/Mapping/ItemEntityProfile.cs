using AutoMapper;
using Dto = BSF.DAL.Abstractions.Dto.ItemEntityDto;
using Entity = BSF.DAL.Entities.ItemEntity;

namespace BSF.DAL.Mapping
{
    internal sealed class ItemEntityProfile : Profile
    {
        public ItemEntityProfile()
        {
            CreateMap<Dto, Entity>()
                .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
                .ForMember(x => x.Name, o => o.MapFrom(m => m.Name))
                .ForMember(x => x.Code, o => o.MapFrom(m => m.Code))
                .ForMember(x => x.Description, o => o.MapFrom(m => m.Description))
                .ForMember(x => x.CategoryId, o => o.MapFrom(m => m.CategoryId))
                .ForMember(x => x.StorageId, o => o.MapFrom(m => m.StorageId))
                .ForMember(x => x.OwnerId, o => o.MapFrom(m => m.OwnerId))
                .ForMember(x => x.UserId, o => o.MapFrom(m => m.UserId))
                .ReverseMap();
        }
    }
}
