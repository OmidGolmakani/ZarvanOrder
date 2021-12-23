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

        public IQueryable<Region> Get(GetRegionsRequest request, bool includeDeleted = false)
        {
            return this
                   .List(p => (includeDeleted || !p.IsDeleted) &&
                   (request.RegionCode.HasValue == false ||
                   p.RegionCode.ToString().Contains(request.RegionCode.Value.ToString())) &&
                   (string.IsNullOrEmpty(request.RegionName) || (!string.IsNullOrEmpty(p.RegionName)
                   && p.RegionName.Contains(request.RegionName))) &&
                   (request.RefId.HasValue == false || p.RefId == request.RefId) &&
                   (request.RegionFatherId.HasValue == false || p.RegionFatherId == request.RegionFatherId) &&
                   (request.Level.HasValue == false || p.Level == (byte)request.Level) &&
                   (request.Active.HasValue == false || p.Active == request.Active)
                   ).Skip(request.PageSize * request.PageIndex).Take(request.PageSize);
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
