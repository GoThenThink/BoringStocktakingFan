using BSF.DAL.Dto;

namespace BSF.DAL.Abstractions
{
    /// <summary>
    /// Интерфейс для код-префикс репозитория
    /// </summary>
    public interface IBaseCodePrefixesRepo : IBaseRepo<int, CodePrefixEntityDto>
    {
    }
}
