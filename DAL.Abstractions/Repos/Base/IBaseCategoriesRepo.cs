using BSF.DAL.Abstractions.Dto;

namespace BSF.DAL.Abstractions
{
    /// <summary>
    /// Интерфейс для репозитория категорий
    /// </summary>
    public interface IBaseCategoriesRepo : IBaseRepo<long, CategoryEntityDto>
    {
    }
}
