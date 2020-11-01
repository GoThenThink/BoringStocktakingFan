using AutoMapper;
using DalDto = BSF.DAL.Abstractions.Dto.StorageEntityDto;
using Dto = BSF.BLL.Abstractions.Dto.StorageBusinessDto;

namespace BSF.DAL.Mapping.Profiles
{
    internal sealed class StorageBusinessProfile : Profile
    {
        public StorageBusinessProfile()
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
