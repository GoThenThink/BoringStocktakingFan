using AutoMapper;
using BSF.BLL.Abstractions;
using BSF.DAL.Abstractions;
using BSF.DAL.Abstractions.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using BusinessDto = BSF.BLL.Abstractions.Dto.StorageBusinessDto;

namespace BSF.BLL
{
    internal sealed class BaseStoragesService : BaseService<long, BusinessDto, StorageEntityDto, IBaseStoragesRepo, IValidator<BusinessDto>>, IBaseStoragesService
    {
        /// <summary/>
        public BaseStoragesService(IBaseStoragesRepo repository,
            IMapper mapper,
            IValidator<BusinessDto> validator)
            :base(repository, mapper, validator)
        {
            PropertyCheckForPatch = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                [nameof(BusinessDto.Name)] = "name",
                [nameof(BusinessDto.CodePrefixId)] = "code_prefix_id",
                [nameof(BusinessDto.Description)] = "description",
                [nameof(BusinessDto.ParentId)] = "parent_id"
            };
        }

    }
}
