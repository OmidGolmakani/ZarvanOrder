using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ZarvanOrder.Data.DbContext;
using ZarvanOrder.Interfaces.Repositores;
using ZarvanOrder.Model.Dtos.Requests.GoodsGroups;
using ZarvanOrder.Model.Entites;

namespace ZarvanOrder.Repositores
{
    public class GoodsGroupRepository : Repository<int, GoodsGroup>, IGoodsGroupRepository
    {
        private readonly DbFactory _dbFactory;
        private readonly IMapper _mapper;
        public GoodsGroupRepository(DbFactory dbFactory, IMapper mapper) : base(dbFactory, mapper)
        {
            this._dbFactory = dbFactory;
            this._mapper = mapper;
        }

        public IQueryable<GoodsGroup> Get(GetGoodsGroupsRequest request, bool includeDeleted = false)
        {
            return this
                 .List(p => (includeDeleted || !p.IsDeleted) &&
                 (request.Code.HasValue == false || p.Code == request.Code) &&
                 (string.IsNullOrEmpty(request.Name) || (!string.IsNullOrEmpty(p.Name)
                 && p.Name.Contains(request.Name))) &&
                 (request.RefId.HasValue == false || p.RefId == request.RefId) &&
                 (request.FatherId.HasValue == false || p.FatherId == request.FatherId) 
                 ).Skip(request.PageSize * request.PageIndex).Take(request.PageSize);
        }

        public Task<GoodsGroup> GetById(GetGoodsGroupRequest request, bool includeDeleted = false)
        {
            return this.DbSet
             .Where(c => c.Id == request.Id && (includeDeleted || !c.IsDeleted))
             .AsNoTracking()
             .FirstOrDefaultAsync();
        }
    }
}
