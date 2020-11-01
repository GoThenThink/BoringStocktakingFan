using AutoMapper;
using BSF.BLL.Abstractions;
using BSF.DAL.Abstractions;
using BSF.DAL.Abstractions.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using BusinessDto = BSF.BLL.Abstractions.Dto.CodePrefixBusinessDto;

namespace BSF.BLL
{
    internal sealed class BaseCodePrefixesService : BaseService<int, BusinessDto, CodePrefixEntityDto, IBaseCodePrefixesRepo, IValidator<BusinessDto>>, IBaseCodePrefixesService
    {
        /// <summary/>
        public BaseCodePrefixesService(IBaseCodePrefixesRepo repository,
            IMapper mapper,
            IValidator<BusinessDto> validator)
            :base(repository, mapper, validator)
        {
            PropertyCheckForPatch = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                [nameof(BusinessDto.Code)] = "code"
            };
        }

    }
}
