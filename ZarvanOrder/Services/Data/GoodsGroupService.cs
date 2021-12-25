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
using ZarvanOrder.Model.Dtos.Requests.GoodsGroups;
using ZarvanOrder.Model.Dtos.Responses.GoodsGroups;
using ZarvanOrder.Model.Dtos.Responses.Pageing;
using ZarvanOrder.Model.Entites;
using ZarvanOrder.Model.Validation;
using ZarvanOrder.Repositores;

namespace ZarvanOrder.Services.Data
{
    public class GoodsGroupService : IGoodsGroupService
    {
        private readonly IGoodsGroupRepository _repository;
        private readonly IMapper _mapper;

        public GoodsGroupService(IGoodsGroupRepository repository,
                               IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<GoodsGroupResponse> Add(AddGoodsGroupRequest request)
        {
            var entity = _mapper.Map<AddGoodsGroupRequest, GoodsGroup>(request);
            GoodsGroupValidation validator = new(this);
            await validator.ValidateAndThrowAsync(entity);
            var result = _mapper.Map<GoodsGroupResponse>(_repository.Add(entity));
            return result;
        }

        public async Task BatchDelete(IEnumerable<DeleteGoodsGroupRequest> request)
        {
            IEnumerable<GoodsGroup> entites = null;
            _mapper.Map<IEnumerable<DeleteGoodsGroupRequest>, IEnumerable<GoodsGroup>>(request, entites);
            _repository.DeleteBatch(entites);
            await Task.Delay(0);
        }

        public async Task BatchUpdate(IEnumerable<EditGoodsGroupRequest> request)
        {
            IEnumerable<GoodsGroup> entites = null;
            _mapper.Map<IEnumerable<EditGoodsGroupRequest>, IEnumerable<GoodsGroup>>(request, entites);
            _repository.UpdateBatch(entites);
            await Task.Delay(0);
        }

        public async Task<int> CountAsync(GetGoodsGroupsRequest request)
        {
            var Count = await _repository.Get(request).ToListAsync();
            return Count.Count();
        }

        public async Task Delete(DeleteGoodsGroupRequest request)
        {
            GoodsGroup entity = await _repository.GetById(_mapper.Map<GetGoodsGroupRequest>(request));
            if (entity == null)
                throw new MyException(System.Net.HttpStatusCode.NotFound, Model.Messages.General.GoodsGroupNotFound);
            _mapper.Map<DeleteGoodsGroupRequest, GoodsGroup>(request, entity);
            var result = _mapper.Map<GoodsGroupResponse>(_repository.Delete(entity));
            await Task.Run(() => result);
        }

        public async Task<GoodsGroupResponse> GetAsync(GetGoodsGroupRequest request)
        {
            return _mapper.Map<GoodsGroupResponse>(await _repository.GetById(request));
        }

        public async Task<ListResponse<GoodsGroupResponse>> GetsAsync(GetGoodsGroupsRequest request)
        {
            var items = _mapper.Map<List<GoodsGroupResponse>>(await _repository.Get(request).ToListAsync());
            return new ListResponse<GoodsGroupResponse>() { Items = items, Total = items.Count() };
        }
        public async Task<GoodsGroupResponse> Update(EditGoodsGroupRequest request)
        {
            GoodsGroup entity = await _repository.GetById(_mapper.Map<GetGoodsGroupRequest>(request));
            if (entity == null)
                throw new MyException(System.Net.HttpStatusCode.NotFound, Model.Messages.General.GoodsGroupNotFound);
            _mapper.Map<EditGoodsGroupRequest, GoodsGroup>(request, entity);
            GoodsGroupValidation validator = new(this);
            await validator.ValidateAndThrowAsync(entity);
            var result = _mapper.Map<GoodsGroupResponse>(_repository.Update(entity));
            return result;
        }
    }
}
