using BSF.BLL.Abstractions;
using BSF.BLL.Abstractions.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BSF.Controllers
{
    /// <summary>
    /// Контроллер для управления владельцами предметов
    /// </summary>
    [Route("api/owners")]
    [ApiController]
    public sealed class OwnersController : BaseController<long, OwnerBusinessDto, IBaseOwnersService>
    {
        /// <summary/>
        public OwnersController(IBaseOwnersService service)
            :base(service)
        {
        }
    }
}