using System.Collections.Generic;
using System.Threading.Tasks;

namespace BSF.BLL.Abstractions
{
    public interface IBaseService<in TBusinessDtoId, TBusinessDto>
    {
        /// <summary>
        /// Базовый интерфейс метода "Создать запись"
        /// </summary>
        Task<TBusinessDto> CreateAsync(TBusinessDto source);

        /// <summary>
        /// Базовый интерфейс метода "Получить запись"
        /// </summary>
        Task<TBusinessDto> GetAsync(TBusinessDtoId id);

        /// <summary>
        /// Базовый интерфейс метода "Получить список"
        /// </summary>
        Task<IReadOnlyList<TBusinessDto>> GetListAsync();

        /// <summary>
        /// Базовый интерфейс метода "Обновить запись"
        /// </summary>
        Task<TBusinessDto> UpdateAsync(TBusinessDtoId id, TBusinessDto source);

        /// <summary>
        /// Базовый интерфейс метода "Удалить запись"
        /// </summary>
        Task<int> DeleteAsync(TBusinessDtoId id);

        /// <summary>
        /// Базовый интерфейс метода "Частично обновить запись"
        /// </summary>
        Task<TBusinessDto> PatchAsync(TBusinessDtoId id, string property, TBusinessDto model);
    }
}
