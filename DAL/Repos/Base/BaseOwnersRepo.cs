using AutoMapper;
using BSF.DAL.Abstractions;
using BSF.DAL.Abstractions.Connection;
using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dto = BSF.DAL.Abstractions.Dto.OwnerEntityDto;
using Entity = BSF.DAL.Entities.OwnerEntity;

namespace BSF.DAL
{
    internal sealed class BaseOwnersRepo : BaseRepo<long, Dto, Entity>, IBaseOwnersRepo
    {
        public BaseOwnersRepo(IDbConnectionFactory conn, IMapper mapper)
            :base(conn, mapper)
        {
            AllowedColumns = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                [nameof(Dto.Name)] = "name",
                [nameof(Dto.Description)] = "description"
            };

            CrudSqlQueries = new Dictionary<CrudMethodsEnum, string>
            {
                [CrudMethodsEnum.Create] = "INSERT INTO owners (name, description, user_id) VALUES (@Name, @Description, @UserId) RETURNING id AS Id;",
                [CrudMethodsEnum.Delete] = "DELETE FROM owners WHERE id=@Id;",
                [CrudMethodsEnum.Get] = "SELECT id AS Id, name AS Name, description AS Description, user_id AS UserId FROM owners WHERE id = @Id;",
                [CrudMethodsEnum.GetList] = "SELECT id AS Id, name AS Name, description AS Description, user_id AS UserId FROM owners;",
                [CrudMethodsEnum.Update] = "UPDATE owners SET name=@Name, description=@Description, user_id=@UserId WHERE id=@Id RETURNING id AS Id, name AS Name, description AS Description, user_id AS UserId;"
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

            string sqlQuery = $"UPDATE owners SET {tablePropertyName}=@{property} WHERE id=@Id RETURNING id AS Id, name AS Name, description AS Description, user_id AS UserId;";
            using var conn = Conn.GetConnection();
            var patchedEntity = await conn.QuerySingleOrDefaultAsync<Entity>(sqlQuery, entity);
            return Mapper.Map<Dto>(patchedEntity);
        }
    }
}
