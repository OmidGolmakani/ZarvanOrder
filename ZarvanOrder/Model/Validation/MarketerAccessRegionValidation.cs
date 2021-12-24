using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Interfaces.DataServices;

namespace ZarvanOrder.Model.Validation
{
    public class MarketerAccessRegionValidation : AbstractValidator<Model.Entites.MarketerAccessRegion>
    {
        private readonly IMarketerAccessRegionService service;

        public MarketerAccessRegionValidation(IMarketerAccessRegionService service)
        {
            this.service = service;
            this.RuleFor(p => p.UserId).NotNull().WithMessage("بازاریاب اجباری می باشد");
            this.RuleFor(p => p.RegionId).NotNull().WithMessage("منطقه مشخص نشده است");
        }   
    }
}
