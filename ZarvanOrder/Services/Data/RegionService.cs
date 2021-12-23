using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZarvanOrder.CustomException;
using ZarvanOrder.Interfaces.DataServices;
using ZarvanOrder.Interfaces.Repositores;
using ZarvanOrder.Model.Dtos.Requests.Regions;
using ZarvanOrder.Model.Dtos.Responses.Pageing;
using ZarvanOrder.Model.Dtos.Responses.Regions;
using ZarvanOrder.Model.Entites;
using ZarvanOrder.Model.Validation;

namespace ZarvanOrder.Services.Data
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _repository;
        private readonly IMapper _mapper;

        public RegionService(IRegionRepository repository,
                             IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<RegionResponse> Add(AddRegionRequest request)
        {
            var entity = _mapper.Map<AddRegionRequest, Region>(request);
            RegionValidator validator = new(this);
            await validator.ValidateAndThrowAsync(entity);
            var result = _mapper.Map<RegionResponse>(_repository.Add(entity));
            return result;
        }

        public async Task BatchDelete(IEnumerable<DeleteRegionRequest> request)
        {
            IEnumerable<Region> entites = null;
            _mapper.Map<IEnumerable<DeleteRegionRequest>, IEnumerable<Region>>(request, entites);
            _repository.DeleteBatch(entites);
            await Task.Delay(0);
        }

        public async Task BatchUpdate(IEnumerable<EditRegionRequest> request)
        {
            IEnumerable<Region> entites = null;
            _mapper.Map<IEnumerable<EditRegionRequest>, IEnumerable<Region>>(request, entites);
            _repository.UpdateBatch(entites);
            await Task.Delay(0);
        }

        public async Task<int> CountAsync(GetRegionsRequest request)
        {
            var Count = await _repository.Get(request).ToListAsync();
            return Count.Count();
        }

        public async Task Delete(DeleteRegionRequest request)
        {
            Region entity = await _repository.GetById(_mapper.Map<GetRegionRequest>(request));
            if (entity == null)
                throw new MyException(System.Net.HttpStatusCode.NotFound, Model.Messages.General.RegionNotFound);
            _mapper.Map<DeleteRegionRequest, Region>(request, entity);
            var result = _mapper.Map<RegionResponse>(_repository.Delete(entity));
            await Task.Run(() => result);
        }

        public async Task<RegionResponse> GetAsync(GetRegionRequest request)
        {
            return _mapper.Map<RegionResponse>(await _repository.GetById(request));
        }

        public async Task<ListResponse<RegionResponse>> GetsAsync(GetRegionsRequest request)
        {
            var items = _mapper.Map<List<RegionResponse>>(await _repository.Get(request).ToListAsync());
            return new ListResponse<RegionResponse>() { Items = items, Total = items.Count() };
        }

        public async Task<RegionResponse> Update(EditRegionRequest request)
        {
            Region entity = await _repository.GetById(_mapper.Map<GetRegionRequest>(request));
            if (entity == null)
                throw new MyException(System.Net.HttpStatusCode.NotFound, Model.Messages.General.RegionNotFound);
            _mapper.Map<EditRegionRequest, Region>(request, entity);
            RegionValidator validator = new(this);
            await validator.ValidateAndThrowAsync(entity);
            var result = _mapper.Map<RegionResponse>(_repository.Update(entity));
            return result;
        }
    }
}
