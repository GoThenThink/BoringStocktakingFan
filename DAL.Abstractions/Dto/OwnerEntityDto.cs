using System;

namespace BSF.DAL.Abstractions.Dto
{
    /// <summary>
    /// Транспортная модель объекта "Владелец предмета" для использования в бизнес-логике
    /// </summary>
    public class OwnerEntityDto
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
