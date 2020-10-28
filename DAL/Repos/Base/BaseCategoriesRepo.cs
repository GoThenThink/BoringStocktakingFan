using AutoMapper;
using BSF.DAL.Abstractions;
using BSF.DAL.Abstractions.Connection;
using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dto = BSF.DAL.Abstractions.Dto.CategoryEntityDto;
using Entity = BSF.DAL.Entities.CategoryEntity;

namespace BSF.DAL
{
    internal sealed class BaseCategoriesRepo : BaseRepo<long, Dto, Entity>, IBaseCategoriesRepo
    {
        public BaseCategoriesRepo(IDbConnectionFactory conn, IMapper mapper)
            :base(conn, mapper)
        {
            AllowedColumns = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                [nameof(Dto.Name)] = "name",
                [nameof(Dto.CodePrefixId)] = "code_prefix_id",
                [nameof(Dto.Description)] = "description",
                [nameof(Dto.ParentId)] = "parent_id"

            };

            CrudSqlQueries = new Dictionary<CrudMethodsEnum, string>
            {
                [CrudMethodsEnum.Create] = "INSERT INTO categories (name, code_prefix_id, description, parent_id, user_id) VALUES (@Name, @CodePrefixId, @Description, @ParentId, @UserId) RETURNING id AS Id;",
                [CrudMethodsEnum.Delete] = "DELETE FROM categories WHERE id=@Id;",
                [CrudMethodsEnum.Get] = "SELECT id AS Id, name AS Name, code_prefix_id AS CodePrefixId, description AS Description, parent_id AS ParentId, user_id AS UserId FROM categories WHERE id = @Id;",
                [CrudMethodsEnum.GetList] = "SELECT id AS Id, name AS Name, code_prefix_id AS CodePrefixId, description AS Description, parent_id AS ParentId, user_id AS UserId FROM categories;",
                [CrudMethodsEnum.Update] = "UPDATE categories SET name=@Name, code_prefix_id=@CodePrefixId, description=@Description, parent_id=@ParentId, user_id=@UserId WHERE id=@Id RETURNING id AS Id, name AS Name, code_prefix_id AS CodePrefixId, description AS Description, parent_id AS ParentId, user_id AS UserId;"
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

            string sqlQuery = $"UPDATE categories SET {tablePropertyName}=@{property} WHERE id=@Id RETURNING id AS Id, name AS Name, code_prefix_id AS CodePrefixId, description AS Description, parent_id AS ParentId, user_id AS UserId;";
            using var conn = Conn.GetConnection();
            var patchedEntity = await conn.QuerySingleOrDefaultAsync<Entity>(sqlQuery, entity);
            return Mapper.Map<Dto>(patchedEntity);
        }
    }
}
