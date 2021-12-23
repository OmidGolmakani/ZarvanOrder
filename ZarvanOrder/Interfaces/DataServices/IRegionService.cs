using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Model.Dtos.Requests.Regions;
using ZarvanOrder.Model.Dtos.Responses.Regions;

namespace ZarvanOrder.Interfaces.DataServices
{
    public interface IRegionService : IService<AddRegionRequest, EditRegionRequest, DeleteRegionRequest, RegionResponse>,
                                      IGetService<GetRegionRequest, GetRegionsRequest, RegionResponse>
    {
        
    }
}
