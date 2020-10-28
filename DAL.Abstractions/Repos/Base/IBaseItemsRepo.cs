using BSF.DAL.Dto;

namespace BSF.DAL.Abstractions
{
    /// <summary>
    /// Интерфейс для репозитория предметов
    /// </summary>
    public interface IBaseItemsRepo : IBaseRepo<long, ItemEntityDto>
    {
    }
}
