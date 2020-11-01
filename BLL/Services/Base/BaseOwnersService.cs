using AutoMapper;
using BSF.BLL.Abstractions;
using BSF.DAL.Abstractions;
using BSF.DAL.Abstractions.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using BusinessDto = BSF.BLL.Abstractions.Dto.OwnerBusinessDto;

namespace BSF.BLL
{
    internal sealed class BaseOwnersService : BaseService<long, BusinessDto, OwnerEntityDto, IBaseOwnersRepo, IValidator<BusinessDto>>, IBaseOwnersService
    {
        /// <summary/>
        public BaseOwnersService(IBaseOwnersRepo repository,
            IMapper mapper,
            IValidator<BusinessDto> validator)
            :base(repository, mapper, validator)
        {
            PropertyCheckForPatch = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                [nameof(BusinessDto.Name)] = "name",
                [nameof(BusinessDto.Description)] = "description"
            };
        }

    }
}
