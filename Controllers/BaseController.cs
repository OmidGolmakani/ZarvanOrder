using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZarvanOrder.Filters;

namespace ZarvanOrder.Controllers
{
    [Route("api/[controller]")]
    [Produces(typeof(JsonResult))]
    [ApiController]
    //[CustomExceptionFilter]
    [CustomAuthorizationFilter]
    public class BaseController : ControllerBase
    {
    }
}
