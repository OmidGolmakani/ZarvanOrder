using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZarvanOrder.Interfaces.Controllers;
using ZarvanOrder.Interfaces.DataServices;
using ZarvanOrder.Model.Dtos.Requests.Regions;
using ZarvanOrder.Services.Data;

namespace ZarvanOrder.Controllers
{
    public class RegionController : BaseController, IController<AddRegionRequest, EditRegionRequest, DeleteRegionRequest>,
                                                    IGetController<GetRegionRequest, GetRegionsRequest>
    {
        private readonly IRegionService _RegionService;

        public RegionController(IRegionService RegionService)
        {
            this._RegionService = RegionService;
        }
        [HttpDelete("BatchDelete")]
        public async Task<IActionResult> BachDelete([FromForm] List<DeleteRegionRequest> request)
        {
            await _RegionService.BatchDelete(request);
            return Ok();
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromForm] DeleteRegionRequest request)
        {
            await _RegionService.Delete(request);
            return Ok();
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] GetRegionRequest request)
        {
            return Ok(await _RegionService.GetAsync(request));
        }
        [HttpGet("Gets")]
        public async Task<IActionResult> Gets([FromQuery] GetRegionsRequest request)
        {
            return Ok(await _RegionService.GetsAsync(request));
        }
        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromForm] AddRegionRequest request)
        {
            var result = await _RegionService.Add(request);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }
        [HttpPut("Put")]
        public async Task<IActionResult> Put([FromForm] EditRegionRequest request)
        {
            var result = await _RegionService.Update(request);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }
    }
}
