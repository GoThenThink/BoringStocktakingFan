namespace BSF.DAL.Entities
{
    /// <summary>
    /// Интерфейс для доступа к идентификационному номеру объекта БД
    /// </summary>
    public interface IEntityId<TId>
    {
        /// <summary>
        /// Идентификационный номер.
        /// </summary>
        public TId Id { get; set; }
    }
}
