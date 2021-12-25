using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Model.Dtos.Requests.GoodsGroups;
using ZarvanOrder.Model.Entites;

namespace ZarvanOrder.Interfaces.Repositores
{
    public interface IGoodsGroupRepository : IRepository<int, Model.Entites.GoodsGroup>,
                                             IGetRepository<GetGoodsGroupRequest, GetGoodsGroupsRequest, GoodsGroup>
    {
        
    }
}
