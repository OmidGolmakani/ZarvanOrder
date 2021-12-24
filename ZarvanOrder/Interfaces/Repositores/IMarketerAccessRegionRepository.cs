using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Model.Dtos.Requests.MarketerAccessRegions;
using ZarvanOrder.Model.Entites;

namespace ZarvanOrder.Interfaces.Repositores
{
    public interface IMarketerAccessRegionRepository : IRepository<long, Model.Entites.MarketerAccessRegion>,
                                                       IGetRepository<GetMarketerAccessRegionRequest, GetMarketerAccessRegionsRequest, MarketerAccessRegion>
    {
        
    }
}
