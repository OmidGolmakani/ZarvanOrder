using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Model.Dtos.Requests.GoodsGroups;
using ZarvanOrder.Model.Dtos.Responses.GoodsGroups;

namespace ZarvanOrder.Interfaces.DataServices
{
    public interface IGoodsGroupService : IService<AddGoodsGroupRequest, EditGoodsGroupRequest, DeleteGoodsGroupRequest, GoodsGroupResponse>,
                                          IGetService<GetGoodsGroupRequest, GetGoodsGroupsRequest, GoodsGroupResponse>
    {
        
    }
}
