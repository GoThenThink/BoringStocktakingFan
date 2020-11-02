using AutoMapper;
using BSF.BLL.Abstractions;
using BSF.DAL.Abstractions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BSF.BLL
{
    /// <summary>
    /// Базовый класс для сервисов, содержащих бизнес-логику
    /// </summary>
    /// <typeparam name="TBusinessDtoId">Тип идентификатора объекта.</typeparam>
    /// <typeparam name="TBusinessDto">Тип транспортной модели объекта уровня бизнес-логики.</typeparam>
    /// <typeparam name="TDbDto">Тип транспортной модели объекта уровня базы данных.</typeparam>
    /// <typeparam name="TRepository">Тип репозитория.</typeparam>
    /// <typeparam name="TValidator">Тип валидатора.</typeparam>
    public abstract class BaseService<TBusinessDtoId, TBusinessDto, TDbDto, TRepository, TValidator> : IBaseService<TBusinessDtoId, TBusinessDto>
        where TRepository : IBaseRepo<TBusinessDtoId, TDbDto>
        where TValidator : IValidator<TBusinessDto>
    {
        /// <summary>
        /// Экземпляр репозитория.
        /// </summary>
        protected readonly TRepository Repository;
        /// <summary>
        /// Класс для конвертации моделей БД в транспортные модели и наоборот.
        /// </summary>
        protected readonly IMapper Mapper;
        /// <summary>
        /// Класс для валидации входящих данных.
        /// </summary>
        protected readonly TValidator Validator;
        /// <summary>
        /// Список полей, доступных для патча.
        /// </summary>
        protected Dictionary<string, string> PropertyCheckForPatch;

        /// <summary/>
        protected BaseService(TRepository repository,
            IMapper mapper,
            TValidator validator)
        {
            Repository = repository;
            Mapper = mapper;
            Validator = validator;
        }

        /// <inheritdoc cref="IBaseService{TBusinessDtoId, TBusinessDto}.CreateAsync(TBusinessDto)"/>
        public async Task<TBusinessDto> CreateAsync(TBusinessDto source)
        {
            await Validator.ValidateAndThrowAsync(source);

            var dalObject = Mapper.Map<TDbDto>(source);
            return Mapper.Map<TBusinessDto>(await Repository.CreateAsync(dalObject));
        }

        /// <inheritdoc cref="IBaseService{TBusinessDtoId, TBusinessDto}.DeleteAsync(TBusinessDtoId)"/>
        public Task<int> DeleteAsync(TBusinessDtoId id)
        {
            return Repository.DeleteAsync(id);
        }

        /// <inheritdoc cref="IBaseService{TBusinessDtoId, TBusinessDto}.GetAsync(TBusinessDtoId)"/>
        public async Task<TBusinessDto> GetAsync(TBusinessDtoId id)
        {
            var requestedDalObject = await Repository.GetAsync(id);
            if (requestedDalObject is null)
                throw new ArgumentException($"{typeof(TBusinessDto).Name} объект по заданному идентификатору не найден.");

            return Mapper.Map<TBusinessDto>(requestedDalObject);
        }

        /// <inheritdoc cref="IBaseService{TBusinessDtoId, TBusinessDto}.GetListAsync"/>
        public async Task<IReadOnlyList<TBusinessDto>> GetListAsync()
        {
            return Mapper.Map<IReadOnlyList<TBusinessDto>>(await Repository.GetListAsync());
        }

        /// <inheritdoc cref="IBaseService{TBusinessDtoId, TBusinessDto}.PatchAsync(TBusinessDtoId, string, TBusinessDto)"/>
        public async Task<TBusinessDto> PatchAsync(TBusinessDtoId id, string property, TBusinessDto model)
        {
            if(!PropertyCheckForPatch.TryGetValue(property, out _))
            {
                throw new ArgumentException($"{property} поле недоступно для редактирования или оно не существует.");
            }

            var validationResult = await Validator.ValidateAsync(model, options => { options.ThrowOnFailures(); options.IncludeProperties(property); });

            var dalObject = Mapper.Map<TDbDto>(model);

            var requestedDalObject = await Repository.PatchAsync(id, property, dalObject);
            if (requestedDalObject is null)
                throw new ArgumentException($"{typeof(TBusinessDto).Name} объект по заданному идентификатору не найден.");

            return Mapper.Map<TBusinessDto>(requestedDalObject);
        }

        /// <inheritdoc cref="IBaseService{TBusinessDtoId, TBusinessDto}.UpdateAsync(TBusinessDtoId, TBusinessDto)"/>
        public async Task<TBusinessDto> UpdateAsync(TBusinessDtoId id, TBusinessDto source)
        {
            await Validator.ValidateAndThrowAsync(source);

            var dalObject = Mapper.Map<TDbDto>(source);
            var requestedDalObject = await Repository.UpdateAsync(id, dalObject);
            if (requestedDalObject is null)
                throw new ArgumentException($"{typeof(TBusinessDto).Name} объект по заданному идентификатору не найден.");

            return Mapper.Map<TBusinessDto>(requestedDalObject);
        }
    }
}
