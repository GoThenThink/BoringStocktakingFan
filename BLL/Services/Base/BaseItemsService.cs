using AutoMapper;
using BSF.BLL.Abstractions;
using BSF.DAL.Abstractions;
using BSF.DAL.Abstractions.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using BusinessDto = BSF.BLL.Abstractions.Dto.ItemBusinessDto;

namespace BSF.BLL
{
    internal sealed class BaseItemsService : BaseService<long, BusinessDto, ItemEntityDto, IBaseItemsRepo, IValidator<BusinessDto>>, IBaseItemsService
    {
        /// <summary/>
        public BaseItemsService(IBaseItemsRepo repository,
            IMapper mapper,
            IValidator<BusinessDto> validator)
            :base(repository, mapper, validator)
        {
            PropertyCheckForPatch = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                [nameof(BusinessDto.Name)] = "name",
                [nameof(BusinessDto.Code)] = "code",
                [nameof(BusinessDto.Description)] = "description",
                [nameof(BusinessDto.CategoryId)] = "category_id",
                [nameof(BusinessDto.StorageId)] = "storage_id",
                [nameof(BusinessDto.OwnerId)] = "owner_id"
            };
        }

    }
}
