using BSF.DAL.Dto;

namespace BSF.DAL.Abstractions
{
    /// <summary>
    /// Интерфейс для репозитория "Владельцы предметов"
    /// </summary>
    public interface IBaseOwnersRepo : IBaseRepo<long, OwnerEntityDto>
    {
    }
}
