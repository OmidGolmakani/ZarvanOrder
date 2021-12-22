using ZarvanOrder.Model.Dtos.Requests.Regions;
using ZarvanOrder.Model.Entites;

namespace ZarvanOrder.Interfaces.Repositores
{
    public interface IRegionRepository : IRepository<int, Region>, 
                                         IGetRepository<GetRegionRequest, GetRegionsRequest, Region>
    {

    }
}
