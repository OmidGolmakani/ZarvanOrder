using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.CustomException;
using ZarvanOrder.Interfaces.DataServices;
using ZarvanOrder.Interfaces.Repositores;
using ZarvanOrder.Model.Dtos.Requests.MarketerAccessRegions;
using ZarvanOrder.Model.Dtos.Responses.MarketerAccessRegions;
using ZarvanOrder.Model.Dtos.Responses.Pageing;
using ZarvanOrder.Model.Entites;
using ZarvanOrder.Model.Validation;
using ZarvanOrder.Repositores;

namespace ZarvanOrder.Services.Data
{
    public class MarketerAccessRegionService : IMarketerAccessRegionService
    {
        private readonly IMarketerAccessRegionRepository _repository;
        private readonly IMapper _mapper;

        public MarketerAccessRegionService(IMarketerAccessRegionRepository repository,
                                           IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<MarketerAccessRegionResponse> Add(AddMarketerAccessRegionRequest request)
        {
            var entity = _mapper.Map<AddMarketerAccessRegionRequest, MarketerAccessRegion>(request);
            MarketerAccessRegionValidation validator = new(this);
            await validator.ValidateAndThrowAsync(entity);
            var result = _mapper.Map<MarketerAccessRegionResponse>(_repository.Add(entity));
            return result;
        }

        public async Task BatchDelete(IEnumerable<DeleteMarketerAccessRegionRequest> request)
        {
            IEnumerable<MarketerAccessRegion> entites = null;
            _mapper.Map<IEnumerable<DeleteMarketerAccessRegionRequest>, IEnumerable<MarketerAccessRegion>>(request, entites);
            _repository.DeleteBatch(entites);
            await Task.Delay(0);
        }

        public async Task BatchUpdate(IEnumerable<EditMarketerAccessRegionRequest> request)
        {
            IEnumerable<MarketerAccessRegion> entites = null;
            _mapper.Map<IEnumerable<EditMarketerAccessRegionRequest>, IEnumerable<MarketerAccessRegion>>(request, entites);
            _repository.UpdateBatch(entites);
            await Task.Delay(0);
        }

        public async Task<int> CountAsync(GetMarketerAccessRegionsRequest request)
        {
            var Count = await _repository.Get(request).ToListAsync();
            return Count.Count();
        }

        public async Task Delete(DeleteMarketerAccessRegionRequest request)
        {
            MarketerAccessRegion entity = await _repository.GetById(_mapper.Map<GetMarketerAccessRegionRequest>(request));
            if (entity == null)
                throw new MyException(System.Net.HttpStatusCode.NotFound, Model.Messages.General.RecordNotFound);
            _mapper.Map<DeleteMarketerAccessRegionRequest, MarketerAccessRegion>(request, entity);
            var result = _mapper.Map<MarketerAccessRegionResponse>(_repository.Delete(entity));
            await Task.Run(() => result);
        }

        public async Task<MarketerAccessRegionResponse> GetAsync(GetMarketerAccessRegionRequest request)
        {
            return _mapper.Map<MarketerAccessRegionResponse>(await _repository.GetById(request));
        }

        public async Task<ListResponse<MarketerAccessRegionResponse>> GetsAsync(GetMarketerAccessRegionsRequest request)
        {
            var items = _mapper.Map<List<MarketerAccessRegionResponse>>(await _repository.Get(request).ToListAsync());
            return new ListResponse<MarketerAccessRegionResponse>() { Items = items, Total = items.Count() };
        }
        public async Task<MarketerAccessRegionResponse> Update(EditMarketerAccessRegionRequest request)
        {
            MarketerAccessRegion entity = await _repository.GetById(_mapper.Map<GetMarketerAccessRegionRequest>(request));
            if (entity == null)
                throw new MyException(System.Net.HttpStatusCode.NotFound, Model.Messages.General.RecordNotFound);
            _mapper.Map<EditMarketerAccessRegionRequest, MarketerAccessRegion>(request, entity);
            MarketerAccessRegionValidation validator = new(this);
            await validator.ValidateAndThrowAsync(entity);
            var result = _mapper.Map<MarketerAccessRegionResponse>(_repository.Update(entity));
            return result;
        }
    }
}
