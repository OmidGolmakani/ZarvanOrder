using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Interfaces.Controllers
{
    public interface IController<TAddRequest, TEditRequest, TDeleteRequest>
    {
        Task<IActionResult> Post(TAddRequest request);
        Task<IActionResult> Put(TEditRequest request);
        Task<IActionResult> Delete(TDeleteRequest request);
        Task<IActionResult> BachDelete(List<TDeleteRequest> request);
    }
}
