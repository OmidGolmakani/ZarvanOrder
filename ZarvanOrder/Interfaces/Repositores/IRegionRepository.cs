using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Model.Dtos.Requests.Regions;
using ZarvanOrder.Model.Entites;

namespace ZarvanOrder.Interfaces.Repositores
{
    public interface IRegionRepository : IRepository<int, Model.Entites.Region>, IGetRepository<GetRegionRequest, GetsRegionRequest, Region>
    {

    }
}
