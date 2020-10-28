using AutoMapper;
using BSF.DAL.Abstractions;
using BSF.DAL.Abstractions.Connection;
using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dto = BSF.DAL.Abstractions.Dto.ItemEntityDto;
using Entity = BSF.DAL.Entities.ItemEntity;

namespace BSF.DAL
{
    internal sealed class BaseItemsRepo : BaseRepo<long, Dto, Entity>, IBaseItemsRepo
    {
        public BaseItemsRepo(IDbConnectionFactory conn, IMapper mapper)
            :base(conn, mapper)
        {
            AllowedColumns = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                [nameof(Dto.Name)] = "name",
                [nameof(Dto.Code)] = "code",
                [nameof(Dto.Description)] = "description",
                [nameof(Dto.CategoryId)] = "category_id",
                [nameof(Dto.StorageId)] = "storage_id",
                [nameof(Dto.OwnerId)] = "owner_id"

            };

            CrudSqlQueries = new Dictionary<CrudMethodsEnum, string>
            {
                [CrudMethodsEnum.Create] = "INSERT INTO items (name, code, description, category_id, storage_id, owner_id, user_id) VALUES (@Name, @Code, @Description, @CategoryId, @StorageId, @OwnerId, @UserId) RETURNING id AS Id;",
                [CrudMethodsEnum.Delete] = "DELETE FROM items WHERE id=@Id;",
                [CrudMethodsEnum.Get] = "SELECT id AS Id, name AS Name, code AS Code, description AS Description, category_id AS CategoryId, storage_id AS StorageId, owner_id AS OwnerId, user_id AS UserId FROM items WHERE id = @Id;",
                [CrudMethodsEnum.GetList] = "SELECT id AS Id, name AS Name, code AS Code, description AS Description, category_id AS CategoryId, storage_id AS StorageId, owner_id AS OwnerId, user_id AS UserId FROM items;",
                [CrudMethodsEnum.Update] = "UPDATE items SET name=@Name, code=@Code, description=@Description, category_id=@CategoryId, storage_id=@StorageId, owner_id=@OwnerId, user_id=@UserId WHERE id=@Id RETURNING id AS Id, name AS Name, code AS Code, description AS Description, category_id AS CategoryId, storage_id AS StorageId, owner_id AS OwnerId, user_id AS UserId;"
            };
        }

        /// <summary>
        /// Обновление одного поля объекта.
        /// </summary>
        /// <param name="id">Идентификационный номер объекта.</param>
        /// <param name="property">Название поля объекта.</param>
        /// <param name="model">Модель объекта, содержащая новое значение поля.</param>
        /// <returns>Обновленный объект.</returns>
        public override async Task<Dto> PatchAsync(long id, string property, Dto model)
        {
            var tablePropertyName = AllowedColumns.GetValueOrDefault(property);
            var entity = Mapper.Map<Entity>(model);

            entity.Id = id;

            string sqlQuery = $"UPDATE items SET {tablePropertyName}=@{property} WHERE id=@Id RETURNING id AS Id, name AS Name, code AS Code, description AS Description, category_id AS CategoryId, storage_id AS StorageId, owner_id AS OwnerId, user_id AS UserId;";
            using var conn = Conn.GetConnection();
            var patchedEntity = await conn.QuerySingleOrDefaultAsync<Entity>(sqlQuery, entity);
            return Mapper.Map<Dto>(patchedEntity);
        }
    }
}
