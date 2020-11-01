using AutoMapper;
using BSF.BLL.Abstractions;
using BSF.DAL.Abstractions;
using BSF.DAL.Abstractions.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using BusinessDto = BSF.BLL.Abstractions.Dto.CategoryBusinessDto;

namespace BSF.BLL
{
    internal sealed class BaseCategoriesService : BaseService<long, BusinessDto, CategoryEntityDto, IBaseCategoriesRepo, IValidator<BusinessDto>>, IBaseCategoriesService
    {
        /// <summary/>
        public BaseCategoriesService(IBaseCategoriesRepo repository,
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
