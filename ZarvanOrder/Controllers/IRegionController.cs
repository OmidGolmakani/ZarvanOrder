using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Interfaces.Controllers;
using ZarvanOrder.Model.Dtos.Requests.Regions;

namespace ZarvanOrder.Controllers
{
    public interface IRegionController : IController<AddRegionRequest, EditRegionRequest, DeleteRegionRequest>,
                                         IGetController<GetRegionRequest, GetRegionsRequest>
    {
        
    }
}
