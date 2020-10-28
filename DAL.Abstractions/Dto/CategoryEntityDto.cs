using System;

namespace BSF.DAL.Abstractions.Dto
{
    /// <summary>
    /// Транспортная модель объекта "Категория" для использования в бизнес-логике
    /// </summary>
    public class CategoryEntityDto
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
