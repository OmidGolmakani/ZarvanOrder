using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Interfaces.DataServices;

namespace ZarvanOrder.Model.Validation
{
    public class RegionValidation : AbstractValidator<Entites.Region>
    {
        private readonly IRegionService _service;

        public RegionValidation(IRegionService service)
        {
            this._service = service;
            this.RuleFor(p => p.RegionName).NotNull().WithMessage("نام منطقه اجباری می باشد");
            this.RuleFor(p => p.RefId).NotNull();
            this.RuleFor(p => p).MustAsync((p, cancellation) => IsUniqeCodeAsync(p)).WithMessage("کد منطقه تکراری می باشد");
            this.RuleFor(p => p.Active).NotNull();

        }
        private async Task<bool> IsUniqeCodeAsync(Entites.Region request)
        {
            var result = await _service.GetsAsync(new Dtos.Requests.Regions.GetRegionsRequest()
            {
                RegionCode = request.RegionCode,
                Level = (Enums.Region.Level)request.Level,
                RegionFatherId = request.RegionFatherId
            });
            return result.Items.Count(p => p.Id != request.Id) != 0 ? false : true;
        }

    }
}
