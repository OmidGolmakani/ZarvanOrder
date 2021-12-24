using ZarvanOrder.Model.Dtos.Requests.Regions;

namespace ZarvanOrder.Interfaces.Controllers
{
    public interface IRegionController : IController<AddRegionRequest, EditRegionRequest, DeleteRegionRequest>,
                                         IGetController<GetRegionRequest, GetRegionsRequest>
    {
        
    }
}
