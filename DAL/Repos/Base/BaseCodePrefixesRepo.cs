using AutoMapper;
using BSF.DAL.Abstractions;
using BSF.DAL.Abstractions.Connection;
using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dto = BSF.DAL.Abstractions.Dto.CodePrefixEntityDto;
using Entity = BSF.DAL.Entities.CodePrefixEntity;

namespace BSF.DAL
{
    internal sealed class BaseCodePrefixesRepo : BaseRepo<int, Dto, Entity>, IBaseCodePrefixesRepo
    {
        public BaseCodePrefixesRepo(IDbConnectionFactory conn, IMapper mapper)
            :base(conn, mapper)
        {
            AllowedColumns = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                [nameof(Dto.Code)] = "code"
            };

            CrudSqlQueries = new Dictionary<CrudMethodsEnum, string>
            {
                [CrudMethodsEnum.Create] = "INSERT INTO code_prefixes (code, user_id) VALUES (@Code, @UserId) RETURNING id AS Id;",
                [CrudMethodsEnum.Delete] = "DELETE FROM code_prefixes WHERE id=@Id;",
                [CrudMethodsEnum.Get] = "SELECT id AS Id, code AS Code, user_id AS UserId FROM code_prefixes WHERE id = @Id;",
                [CrudMethodsEnum.GetList] = "SELECT id AS Id, code AS Code, user_id AS UserId FROM code_prefixes;",
                [CrudMethodsEnum.Update] = "UPDATE code_prefixes SET code=@Code, user_id=@UserId WHERE id=@Id RETURNING id AS Id, code AS Code, user_id AS UserId;"
            };
        }

        /// <summary>
        /// Обновление одного поля объекта.
        /// </summary>
        /// <param name="id">Идентификационный номер объекта.</param>
        /// <param name="property">Название поля объекта.</param>
        /// <param name="model">Модель объекта, содержащая новое значение поля.</param>
        /// <returns>Обновленный объект.</returns>
        public override async Task<Dto> PatchAsync(int id, string property, Dto model)
        {
            var tablePropertyName = AllowedColumns.GetValueOrDefault(property);
            var entity = Mapper.Map<Entity>(model);

            entity.Id = id;

            string sqlQuery = $"UPDATE code_prefixes SET {tablePropertyName}=@{property} WHERE id=@Id RETURNING id AS Id, code AS Code, user_id AS UserId;";
            using var conn = Conn.GetConnection();
            var patchedEntity = await conn.QuerySingleOrDefaultAsync<Entity>(sqlQuery, entity);
            return Mapper.Map<Dto>(patchedEntity);
        }
    }
}
