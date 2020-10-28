using AutoMapper;
using Dto = BSF.DAL.Abstractions.Dto.OwnerEntityDto;
using Entity = BSF.DAL.Entities.OwnerEntity;

namespace BSF.DAL.Mapping
{
    internal sealed class OwnerEntityProfile : Profile
    {
        public OwnerEntityProfile()
        {
            CreateMap<Dto, Entity>()
                .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
                .ForMember(x => x.Name, o => o.MapFrom(m => m.Name))
                .ForMember(x => x.Description, o => o.MapFrom(m => m.Description))
                .ForMember(x => x.UserId, o => o.MapFrom(m => m.UserId))
                .ReverseMap();
        }
    }
}
