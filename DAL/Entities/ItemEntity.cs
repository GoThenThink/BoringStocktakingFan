using System;

namespace BSF.DAL.Entities
{
    /// <summary>
    /// Модель объекта таблицы БД items
    /// </summary>
    internal class ItemEntity : IEntityId<long>
    {
        /// <summary>
        /// Уникальный идентификационный номер(id) предмета.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название предмета.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Код предмета.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Описание предмета.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Идентификационный номер категории.
        /// </summary>
        public long CategoryId { get; set; }

        /// <summary>
        /// Идентификационный номер хранилища.
        /// </summary>
        public long StorageId { get; set; }

        /// <summary>
        /// Идентификационный номер владельца предмета.
        /// </summary>
        public long OwnerId { get; set; }

        /// <summary>
        /// Идентификационный номер пользователя.
        /// </summary>
        public Guid UserId { get; set; }
    }
}
