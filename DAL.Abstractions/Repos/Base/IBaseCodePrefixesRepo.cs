using BSF.DAL.Abstractions.Dto;

namespace BSF.DAL.Abstractions
{
    /// <summary>
    /// Интерфейс для код-префикс репозитория
    /// </summary>
    public interface IBaseCodePrefixesRepo : IBaseRepo<int, CodePrefixEntityDto>
    {
    }
}
