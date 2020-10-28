using System;

namespace BSF.DAL.Entities
{
    /// <summary>
    /// Модель объекта таблицы БД code_prefixes
    /// </summary>
    internal class CodePrefixEntity : IEntityId<int>
    {
        /// <summary>
        /// Уникальный идентификационный номер(id) код-префикса.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Код-префикс.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Идентификационный номер пользователя.
        /// </summary>
        public Guid UserId { get; set; }
    }
}
