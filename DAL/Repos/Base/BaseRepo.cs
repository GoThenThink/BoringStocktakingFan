using AutoMapper;
using BSF.DAL.Abstractions;
using BSF.DAL.Abstractions.Connection;
using BSF.DAL.Entities;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSF.DAL
{
    /// <summary>
    /// Базовый класс для CRUD-репозиториев
    /// </summary>
    /// <typeparam name="TDbDtoId">Идентификационный номер.</typeparam>
    /// <typeparam name="TDbDto">Транспортная модель объекта.</typeparam>
    /// <typeparam name="TEntity">Модель объекта базы данных.</typeparam>
    public abstract class BaseRepo<TDbDtoId, TDbDto, TEntity> : IBaseRepo<TDbDtoId, TDbDto>
        where TEntity : IEntityId<TDbDtoId>
    {
        /// <summary/>
        protected readonly IDbConnectionFactory Conn;

        /// <summary>
        /// Разрешенные поля для редактирования.
        /// </summary>
        protected Dictionary<string, string> AllowedColumns;

        /// <summary>
        /// Класс для конвертации моделей БД в транспортные модели и наоборот.
        /// </summary>
        protected readonly IMapper Mapper;

        /// <summary>
        /// Sql-скрипты для базовых команд: 
        /// 0 - Создание записи, 1 - Удаление записи, 2 - Получение записи,
        /// 3 - Получение списка, 4 - Обновление записи.
        /// </summary>
        protected Dictionary<CrudMethodsEnum, string> CrudSqlQueries;

        /// <summary/>
        public BaseRepo(IDbConnectionFactory conn,
            IMapper mapper)
        {
            Conn = conn;
            Mapper = mapper;
        }

        /// <inheritdoc cref="IBaseRepo{TBusinessModelId, TBusinessModel}.CreateAsync(TBusinessModel)"/>
        public virtual async Task<TDbDto> CreateAsync(TDbDto source)
        {
            var entity = Mapper.Map<TEntity>(source);

            using var conn = Conn.GetConnection();
            entity.Id = await conn.QuerySingleAsync<TDbDtoId>(CrudSqlQueries[CrudMethodsEnum.Create], source);
            return Mapper.Map<TDbDto>(entity);
        }

        /// <inheritdoc cref="IBaseRepo{TBusinessModelId, TBusinessModel}.DeleteAsync(TBusinessModelId)"/>
        public virtual async Task<int> DeleteAsync(TDbDtoId id)
        {
            using var conn = Conn.GetConnection();
            return await conn.ExecuteAsync(CrudSqlQueries[CrudMethodsEnum.Delete], new { id });
        }

        /// <inheritdoc cref="IBaseRepo{TBusinessModelId, TBusinessModel}.GetAsync(TBusinessModelId)"/>
        public virtual async Task<TDbDto> GetAsync(TDbDtoId id)
        {
            using var conn = Conn.GetConnection();
            var entity = await conn.QuerySingleOrDefaultAsync<TEntity>(CrudSqlQueries[CrudMethodsEnum.Get], new { id });
            return Mapper.Map<TDbDto>(entity);
        }

        /// <inheritdoc cref="IBaseRepo{TBusinessModelId, TBusinessModel}.GetListAsync"/>
        public virtual async Task<IReadOnlyList<TDbDto>> GetListAsync()
        {
            using var conn = Conn.GetConnection();
            var entityList = (await conn.QueryAsync<TEntity>(CrudSqlQueries[CrudMethodsEnum.GetList])).ToList();
            return Mapper.Map<IReadOnlyList<TDbDto>>(entityList);
        }

        /// <inheritdoc cref="IBaseRepo{TBusinessModelId, TBusinessModel}.PatchAsync(TBusinessModelId, string, TBusinessModel)"/>
        public abstract Task<TDbDto> PatchAsync(TDbDtoId id, string property, TDbDto model);

        /// <inheritdoc cref="IBaseRepo{TBusinessModelId, TBusinessModel}.UpdateAsync(TBusinessModelId, TBusinessModel)"/>
        public virtual async Task<TDbDto> UpdateAsync(TDbDtoId id, TDbDto source)
        {
            var entity = Mapper.Map<TEntity>(source);
            using var conn = Conn.GetConnection();
            var updatedEntity = await conn.QuerySingleOrDefaultAsync<TEntity>(CrudSqlQueries[CrudMethodsEnum.Update], entity);
            return Mapper.Map<TDbDto>(updatedEntity);
        }
    }
}
