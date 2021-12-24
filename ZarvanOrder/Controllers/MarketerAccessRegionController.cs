using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZarvanOrder.Interfaces.Controllers;
using ZarvanOrder.Interfaces.DataServices;
using ZarvanOrder.Model.Dtos.Requests.MarketerAccessRegions;
using ZarvanOrder.Services.Data;

namespace ZarvanOrder.Controllers
{
    public class MarketerAccessRegionController : BaseController, IMarketerAccessRegionController
    {
        private readonly IMarketerAccessRegionService _MarketerAccessRegionService;

        public MarketerAccessRegionController(IMarketerAccessRegionService MarketerAccessRegionService)
        {
            this._MarketerAccessRegionService = MarketerAccessRegionService;
        }
        [HttpDelete("BatchDelete")]
        public async Task<IActionResult> BachDelete([FromForm] List<DeleteMarketerAccessRegionRequest> request)
        {
            await _MarketerAccessRegionService.BatchDelete(request);
            return Ok();
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromForm] DeleteMarketerAccessRegionRequest request)
        {
            await _MarketerAccessRegionService.Delete(request);
            return Ok();
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] GetMarketerAccessRegionRequest request)
        {
            return Ok(await _MarketerAccessRegionService.GetAsync(request));
        }
        [HttpGet("Gets")]
        public async Task<IActionResult> Gets([FromQuery] GetMarketerAccessRegionsRequest request)
        {
            return Ok(await _MarketerAccessRegionService.GetsAsync(request));
        }
        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromForm] AddMarketerAccessRegionRequest request)
        {
            var result = await _MarketerAccessRegionService.Add(request);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }
        [HttpPut("Put")]
        public async Task<IActionResult> Put([FromForm] EditMarketerAccessRegionRequest request)
        {
            var result = await _MarketerAccessRegionService.Update(request);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }
    }
}
