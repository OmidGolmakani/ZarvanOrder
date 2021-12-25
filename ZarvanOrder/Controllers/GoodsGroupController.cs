using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZarvanOrder.Interfaces.Controllers;
using ZarvanOrder.Interfaces.DataServices;
using ZarvanOrder.Model.Dtos.Requests.GoodsGroups;

namespace ZarvanOrder.Controllers
{
    public class GoodsGroupController : BaseController, IGoodsGroupController
    {
        private readonly IGoodsGroupService _GoodsGroupService;

        public GoodsGroupController(IGoodsGroupService GoodsGroupService)
        {
            this._GoodsGroupService = GoodsGroupService;
        }
        [HttpDelete("BatchDelete")]
        public async Task<IActionResult> BachDelete([FromForm] List<DeleteGoodsGroupRequest> request)
        {
            await _GoodsGroupService.BatchDelete(request);
            return Ok();
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromForm] DeleteGoodsGroupRequest request)
        {
            await _GoodsGroupService.Delete(request);
            return Ok();
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] GetGoodsGroupRequest request)
        {
            return Ok(await _GoodsGroupService.GetAsync(request));
        }
        [HttpGet("Gets")]
        public async Task<IActionResult> Gets([FromQuery] GetGoodsGroupsRequest request)
        {
            return Ok(await _GoodsGroupService.GetsAsync(request));
        }
        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromForm] AddGoodsGroupRequest request)
        {
            var result = await _GoodsGroupService.Add(request);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }
        [HttpPut("Put")]
        public async Task<IActionResult> Put([FromForm] EditGoodsGroupRequest request)
        {
            var result = await _GoodsGroupService.Update(request);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }
    }
}
