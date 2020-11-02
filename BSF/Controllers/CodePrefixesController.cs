using BSF.BLL.Abstractions;
using BSF.BLL.Abstractions.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BSF.Controllers
{
    /// <summary>
    /// Контроллер для управления код-префиксами
    /// </summary>
    [Route("api/code-prefixes")]
    [ApiController]
    public sealed class CodePrefixesController : BaseController<int, CodePrefixBusinessDto, IBaseCodePrefixesService>
    {
        /// <summary/>
        public CodePrefixesController(IBaseCodePrefixesService service)
            :base(service)
        {
        }
    }
}