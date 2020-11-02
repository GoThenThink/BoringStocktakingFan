using BSF.BLL.Abstractions;
using BSF.BLL.Abstractions.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BSF.Controllers
{
    /// <summary>
    /// Контроллер для управления предметами
    /// </summary>
    [Route("api/items")]
    [ApiController]
    public sealed class ItemsController : BaseController<long, ItemBusinessDto, IBaseItemsService>
    {
        /// <summary/>
        public ItemsController(IBaseItemsService service)
            :base(service)
        {
        }
    }
}