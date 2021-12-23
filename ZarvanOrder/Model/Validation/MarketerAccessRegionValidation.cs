using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Validation
{
    public class MarketerAccessRegionValidation : AbstractValidator<Model.Entites.MarketerAccessRegion>
    {
        public MarketerAccessRegionValidation()
        {
            this.RuleFor(p => p.UserId).NotNull().WithMessage("بازاریاب اجباری می باشد");
            this.RuleFor(p => p.RegionId).NotNull().WithMessage("منطقه مشخص نشده است");
        }   
    }
}
