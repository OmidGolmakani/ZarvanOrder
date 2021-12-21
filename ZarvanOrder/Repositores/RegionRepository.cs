using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ZarvanOrder.Data.DbContext;
using ZarvanOrder.Interfaces.Repositores;
using ZarvanOrder.Model.Dtos.Requests.Regions;
using ZarvanOrder.Model.Entites;

namespace ZarvanOrder.Repositores
{
    public class RegionRepository : Repository<int, Region>, IRegionRepository
    {
        private readonly IMapper _mapoper;
        private readonly DbFactory _dbFactory;

        public RegionRepository(DbFactory dbFactory, IMapper mapper) : base(dbFactory, mapper)
        {
            this._dbFactory = dbFactory;
            this._mapoper = mapper;
        }

        public IQueryable<Region> Get(GetsRegionRequest request, bool includeDeleted = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<Region> GetById(GetRegionRequest request, bool includeDeleted = false)
        {
            return this.DbSet
            .Where(c => c.Id == request.Id && (includeDeleted || !c.IsDeleted))
            .AsNoTracking()
            .FirstOrDefaultAsync();
        }
    }
}
