using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Interfaces.DataServices;

namespace ZarvanOrder.Model.Validation
{
    public class GoodsGroupValidation : AbstractValidator<Entites.GoodsGroup>
    {
        private readonly IGoodsGroupService _service;

        public GoodsGroupValidation(IGoodsGroupService service)
        {
            this._service = service;
            RuleFor(p => p.Code).NotNull().WithMessage("کد گروه اجباری میباشد");
            RuleFor(p => p).MustAsync((p, cancellation) => IsUniqeCodeAsync(p)).WithMessage("کد گروه کالا تکراری می باشد");
            RuleFor(p => p.Name).NotNull().WithMessage("نام گروه اجباری میباشد");
            RuleFor(p => p).MustAsync((p, cancellation) => IsUniqeNameAsync(p)).WithMessage("نام گروه کالا تکراری می باشد");
            RuleFor(p => p).MustAsync((p, cancellation) => IsUniqeRefIdAsync(p)).WithMessage("این رکورد قبلا اضافه شده است");
        }
        private async Task<bool> IsUniqeCodeAsync(Entites.GoodsGroup request)
        {
            var result = await _service.GetsAsync(new Dtos.Requests.GoodsGroups.GetGoodsGroupsRequest { Code = request.Code });
            return result.Items.Count(p => p.Id != request.Id) != 0 ? false : true;
        }
        private async Task<bool> IsUniqeNameAsync(Entites.GoodsGroup request)
        {
            var result = await _service.GetsAsync(new Dtos.Requests.GoodsGroups.GetGoodsGroupsRequest { Name = request.Name });
            return result.Items.Count(p => p.Id != request.Id) != 0 ? false : true;
        }
        private async Task<bool> IsUniqeRefIdAsync(Entites.GoodsGroup request)
        {
            var result = await _service.GetsAsync(new Dtos.Requests.GoodsGroups.GetGoodsGroupsRequest { RefId = request.RefId });
            return result.Items.Count(p => p.Id != request.Id) != 0 ? false : true;
        }
    }
}
