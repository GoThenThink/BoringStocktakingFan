using BSF.DAL.Abstractions;
using BSF.DAL.Abstractions.Connection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BSF.DAL
{
    /// <summary>
    /// Базовый класс для CRUD-репозиториев
    /// </summary>
    /// <typeparam name="TBusinessModelId">Идентификационный номер.</typeparam>
    /// <typeparam name="TBusinessModel">Модель объекта.</typeparam>
    public abstract class BaseRepo<TBusinessModelId, TBusinessModel> : IBaseRepo<TBusinessModelId, TBusinessModel>
    {
        /// <summary/>
        protected readonly IDbConnectionFactory Conn;

        /// <summary>
        /// Разрешенные для редактирования поля.
        /// </summary>
        protected readonly Dictionary<string, string> AllowedColumns;

        /// <summary>
        /// Sql-скрипты для базовых команд: 
        /// 0 - Создание записи, 1 - Удаление записи, 2 - Получение записи,
        /// 3 - Получение списка, 4 - Обновление записи.
        /// </summary>
        protected readonly Dictionary<short, string> CrudSqlQueries;

        /// <summary>
        public BaseRepo(IDbConnectionFactory conn, 
            Dictionary<string, string> allowedColumns,
            Dictionary<short, string> crudSqlQueries)
        {
            Conn = conn;
            AllowedColumns = allowedColumns;
            CrudSqlQueries = crudSqlQueries;
        }

        /// <inheritdoc cref="IBaseRepo{TBusinessModelId, TBusinessModel}.CreateAsync(TBusinessModel)"/>
        public virtual async Task<TBusinessModel> CreateAsync(TBusinessModel source)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="IBaseRepo{TBusinessModelId, TBusinessModel}.DeleteAsync(TBusinessModelId)"/>
        public virtual async Task<int> DeleteAsync(TBusinessModelId id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="IBaseRepo{TBusinessModelId, TBusinessModel}.GetAsync(TBusinessModelId)"/>
        public virtual async Task<TBusinessModel> GetAsync(TBusinessModelId id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="IBaseRepo{TBusinessModelId, TBusinessModel}.GetListAsync"/>
        public virtual async Task<IReadOnlyList<TBusinessModel>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="IBaseRepo{TBusinessModelId, TBusinessModel}.PatchAsync(TBusinessModelId, string, TBusinessModel)"/>
        public abstract Task<TBusinessModel> PatchAsync(TBusinessModelId id, string property, TBusinessModel model);

        /// <inheritdoc cref="IBaseRepo{TBusinessModelId, TBusinessModel}.UpdateAsync(TBusinessModelId, TBusinessModel)"/>
        public virtual async Task<TBusinessModel> UpdateAsync(TBusinessModelId id, TBusinessModel source)
        {
            throw new NotImplementedException();
        }
    }
}
