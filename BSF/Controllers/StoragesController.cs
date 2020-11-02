using BSF.BLL.Abstractions;
using BSF.BLL.Abstractions.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BSF.Controllers
{
    /// <summary>
    /// Контроллер для управления хранилищами
    /// </summary>
    [Route("api/storages")]
    [ApiController]
    public sealed class StoragesController : BaseController<long, StorageBusinessDto, IBaseStoragesService>
    {
        /// <summary/>
        public StoragesController(IBaseStoragesService service)
            :base(service)
        {
        }
    }
}