using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Model.Dtos.Requests.MarketerAccessRegions;
using ZarvanOrder.Model.Dtos.Responses.MarketerAccessRegions;

namespace ZarvanOrder.Interfaces.DataServices
{
    public interface IMarketerAccessRegionService : IService<AddMarketerAccessRegionRequest, EditMarketerAccessRegionRequest, DeleteMarketerAccessRegionRequest, MarketerAccessRegionResponse>,
                                                    IGetService<GetMarketerAccessRegionRequest, GetMarketerAccessRegionsRequest, MarketerAccessRegionResponse>
    {
        
    }
}
