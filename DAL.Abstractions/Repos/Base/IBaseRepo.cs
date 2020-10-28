using System.Collections.Generic;
using System.Threading.Tasks;

namespace BSF.DAL.Abstractions
{
    public interface IBaseRepo <in TDbDtoId, TDbDto>
    {
        /// <summary>
        /// Базовый интерфейс метода "Создать запись"
        /// </summary>
        Task<TDbDto> CreateAsync(TDbDto source);

        /// <summary>
        /// Базовый интерфейс метода "Получить запись"
        /// </summary>
        Task<TDbDto> GetAsync(TDbDtoId id);

        /// <summary>
        /// Базовый интерфейс метода "Получить список"
        /// </summary>
        Task<IReadOnlyList<TDbDto>> GetListAsync();

        /// <summary>
        /// Базовый интерфейс метода "Обновить запись"
        /// </summary>
        Task<TDbDto> UpdateAsync(TDbDtoId id, TDbDto source);

        /// <summary>
        /// Базовый интерфейс метода "Удалить запись"
        /// </summary>
        Task<int> DeleteAsync(TDbDtoId id);

        /// <summary>
        /// Базовый интерфейс метода "Частично обновить запись"
        /// </summary>
        Task<TDbDto> PatchAsync(TDbDtoId id, string property, TDbDto model);
    }
}
