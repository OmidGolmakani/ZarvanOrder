using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Model.Dtos.Requests.MarketerAccessRegions;

namespace ZarvanOrder.Interfaces.Controllers
{
    public interface IMarketerAccessRegionController : IController<AddMarketerAccessRegionRequest, EditMarketerAccessRegionRequest, DeleteMarketerAccessRegionRequest>,
                                                       IGetController<GetMarketerAccessRegionRequest, GetMarketerAccessRegionsRequest>
    {

    }
}
