using System;

namespace BSF.DAL.Entities
{
    /// <summary>
    /// Модель объекта таблицы БД categories
    /// </summary>
    internal class CategoryEntity : IEntityId<long>
    {
        /// <summary>
        /// Уникальный идентификационный номер(id) категории.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название категории.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Код-префикс.
        /// </summary>
        public int CodePrefixId { get; set; }

        /// <summary>
        /// Описание категории.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Идентификационный номер родительской категории.
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// Идентификационный номер пользователя.
        /// </summary>
        public Guid UserId { get; set; }
    }
}
