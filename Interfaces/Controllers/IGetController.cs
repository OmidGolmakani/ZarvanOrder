using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Interfaces.Controllers
{
    public interface IGetController<TGetRequest, TGetsRequest>
    {
        Task<IActionResult> Get(TGetRequest request);
        Task<IActionResult> Gets(TGetsRequest request);

    }
}
