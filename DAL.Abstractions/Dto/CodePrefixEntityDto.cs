using System;

namespace BSF.DAL.Abstractions.Dto
{
    /// <summary>
    /// Транспортная модель объекта "Префикс кода" для использования в бизнес-логике
    /// </summary>
    public class CodePrefixEntityDto
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
