using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Interfaces.Controllers
{
    public interface IController<TAddRequest, TEditRequest, TGetRequest, TDeleteRequest>
    {
        Task<IActionResult> Add(TAddRequest request);
        Task<IActionResult> Update(TEditRequest request);
        Task UpdateBatch(IEnumerable<TEditRequest> request);
        Task<IActionResult> Delete(TDeleteRequest request);
    }
}
