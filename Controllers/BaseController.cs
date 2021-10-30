using CurrencyExchange.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZarvanOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomAuthorizationFilter]
    public class BaseController : ControllerBase
    {
    }
}
