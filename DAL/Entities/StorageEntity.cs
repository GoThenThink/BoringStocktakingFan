using System;

namespace BSF.DAL.Entities
{
    /// <summary>
    /// Модель объекта таблицы БД storages
    /// </summary>
    internal class StorageEntity : IEntityId<long>
    {
        /// <summary>
        /// Уникальный идентификационный номер(id) хранилища.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название хранилища.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Код-префикс.
        /// </summary>
        public int? CodePrefixId { get; set; }

        /// <summary>
        /// Описание хранилища.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Идентификационный номер родительского хранилища.
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// Идентификационный номер пользователя.
        /// </summary>
        public Guid UserId { get; set; }
    }
}
