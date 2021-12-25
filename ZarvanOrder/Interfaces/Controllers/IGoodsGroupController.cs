using ZarvanOrder.Model.Dtos.Requests.GoodsGroups;

namespace ZarvanOrder.Interfaces.Controllers
{
    public interface IGoodsGroupController : IController<AddGoodsGroupRequest, EditGoodsGroupRequest, DeleteGoodsGroupRequest>,
                                             IGetController<GetGoodsGroupRequest, GetGoodsGroupsRequest>
    {
        
    }
}
