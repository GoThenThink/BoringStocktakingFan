using System;

namespace BSF.DAL.Entities
{
    /// <summary>
    /// Модель объекта таблицы БД owners
    /// </summary>
    internal class OwnerEntity : IEntityId<long>
    {
        /// <summary>
        /// Уникальный идентификационный номер(id) владельца предмета.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя владельца.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дополнительная информация о владельце.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Идентификационный номер пользователя.
        /// </summary>
        public Guid UserId { get; set; }
    }
}
