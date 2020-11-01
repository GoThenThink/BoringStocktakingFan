using AutoMapper;
using DalDto = BSF.DAL.Abstractions.Dto.OwnerEntityDto;
using Dto = BSF.BLL.Abstractions.Dto.OwnerBusinessDto;

namespace BSF.DAL.Mapping.Profiles
{
    internal sealed class OwnerBusinessProfile : Profile
    {
        public OwnerBusinessProfile()
        {
            CreateMap<Dto, DalDto>()
                .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
                .ForMember(x => x.Name, o => o.MapFrom(m => m.Name))
                .ForMember(x => x.Description, o => o.MapFrom(m => m.Description))
                .ForMember(x => x.UserId, o => o.MapFrom(m => m.UserId))
                .ReverseMap();
        }
    }
}
