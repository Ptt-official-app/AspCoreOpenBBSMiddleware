using Microsoft.AspNetCore.Mvc;

namespace AspCoreOpenBBSMiddleware.Controllers.Base
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    //[Authorize]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
    }
}
