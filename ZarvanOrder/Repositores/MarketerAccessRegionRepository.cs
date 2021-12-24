using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ZarvanOrder.Data.DbContext;
using ZarvanOrder.Interfaces.Repositores;
using ZarvanOrder.Model.Dtos.Requests.MarketerAccessRegions;
using ZarvanOrder.Model.Entites;

namespace ZarvanOrder.Repositores
{
    public class MarketerAccessRegionRepository : Repository<long, MarketerAccessRegion>, IMarketerAccessRegionRepository
    {
        private readonly IMapper _mapoper;
        private readonly DbFactory _dbFactory;

        public MarketerAccessRegionRepository(DbFactory dbFactory, IMapper mapper) : base(dbFactory, mapper)
        {
            this._dbFactory = dbFactory;
            this._mapoper = mapper;
        }

        public IQueryable<MarketerAccessRegion> Get(GetMarketerAccessRegionsRequest request, bool includeDeleted = false)
        {
            return this
                   .List(p => (includeDeleted || !p.IsDeleted) &&
                   (request.MarketerId.HasValue == false ||p.UserId==request.MarketerId) &&
                   (request.MarketerId.HasValue == false || p.UserId == request.MarketerId) 
                   ).Skip(request.PageSize * request.PageIndex).Take(request.PageSize);
        }

        public Task<MarketerAccessRegion> GetById(GetMarketerAccessRegionRequest request, bool includeDeleted = false)
        {
            return this.DbSet
            .Where(c => c.Id == request.Id && (includeDeleted || !c.IsDeleted))
            .AsNoTracking()
            .FirstOrDefaultAsync();
        }
    }
}
