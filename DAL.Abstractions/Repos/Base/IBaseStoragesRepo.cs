using BSF.DAL.Abstractions.Dto;

namespace BSF.DAL.Abstractions
{
    /// <summary>
    /// Интерфейс для репозитория хранилищ
    /// </summary>
    public interface IBaseStoragesRepo : IBaseRepo<long, StorageEntityDto>
    {
    }
}
