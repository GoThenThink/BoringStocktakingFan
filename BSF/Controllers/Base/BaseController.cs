using BSF.BLL.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BSF.Controllers
{
    /// <summary>
    /// Базовый контроллер для CRUD-операций
    /// </summary>
    [ApiController]
    public abstract class BaseController<TBusinessDtoId, TBusinessDto, TService> : ControllerBase
        where TService : IBaseService<TBusinessDtoId, TBusinessDto>
    {
        /// <summary>
        /// Экземпляр сервиса бизнес-логики.
        /// </summary>
        protected readonly TService Service;

        /// <summary/>
        protected BaseController(
            TService service)
        {
            Service = service;
        }

        /// <summary>
        /// Возвращает объект, найденный по заданному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        [HttpGet("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions),
                     nameof(DefaultApiConventions.Get))]
        public virtual async Task<ActionResult<TBusinessDto>> GetAsync(TBusinessDtoId id)
        {
            return Ok(await Service.GetAsync(id));
        }

        /// <summary>
        /// Возращает все объекты.
        /// </summary>
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions),
                     nameof(DefaultApiConventions.Get))]
        public virtual async Task<ActionResult<IReadOnlyList<TBusinessDto>>> GetListAsync()
        {
            return Ok(await Service.GetListAsync());
        }

        /// <summary>
        /// Создает новый объект.
        /// </summary>
        /// <param name="model">Объект для создания.</param>
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions),
                     nameof(DefaultApiConventions.Post))]
        public virtual async Task<ActionResult<TBusinessDto>> PostAsync([FromBody] TBusinessDto model)
        {
            return Ok(await Service.CreateAsync(model));
        }

        /// <summary>
        /// Обновление поля существующего объекта.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="property">Название поля.</param>
        /// <param name="model">Объект, который содержит новое значение поля.</param>
        [HttpPatch("{id}/{property}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public virtual async Task<ActionResult<TBusinessDto>> PatchAsync(TBusinessDtoId id, string property, [FromBody] TBusinessDto model)
        {
            return Ok(await Service.PatchAsync(id, property, model));
        }

        /// <summary>
        /// Обновляет существующий объект.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="model">Новый объект.</param>
        [HttpPut("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions),
                     nameof(DefaultApiConventions.Put))]
        public virtual async Task<TBusinessDto> PutAsync(TBusinessDtoId id, [FromBody] TBusinessDto model)
        {
            return await Service.UpdateAsync(id, model);
        }

        /// <summary>
        /// Удаляет существующий объект.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        [HttpDelete("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions),
                     nameof(DefaultApiConventions.Delete))]
        public virtual async Task<IActionResult> DeleteAsync(TBusinessDtoId id)
        {
            return Ok(await Service.DeleteAsync(id));
        }
    }
}
