using BSF.BLL.Abstractions;
using BSF.BLL.Abstractions.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BSF.Controllers
{
    /// <summary>
    /// Контроллер для управления категориями
    /// </summary>
    [Route("api/categories")]
    [ApiController]
    public sealed class CategoriesController : BaseController<long, CategoryBusinessDto, IBaseCategoriesService>
    {
        /// <summary/>
        public CategoriesController(IBaseCategoriesService service)
            :base(service)
        {
        }
    }
}