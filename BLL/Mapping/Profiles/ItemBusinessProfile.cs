using AutoMapper;
using DalDto = BSF.DAL.Abstractions.Dto.ItemEntityDto;
using Dto = BSF.BLL.Abstractions.Dto.ItemBusinessDto;

namespace BSF.DAL.Mapping.Profiles
{
    internal sealed class ItemBusinessProfile : Profile
    {
        public ItemBusinessProfile()
        {
            CreateMap<Dto, DalDto>()
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
