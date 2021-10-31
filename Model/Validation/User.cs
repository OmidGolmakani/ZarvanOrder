using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Validation
{
    internal class User : AbstractValidator<Entites.User>
    {
        public User()
        {
            RuleFor(p => p.Id).Null().WithMessage("آی دی اجباری می باشد");
            RuleFor(p => p.Name).Null().Length(0).WithMessage("نام اجباری می باشد").
                                 MaximumLength(60).WithMessage(Messages.General.MaximumLength);
            RuleFor(p => p.Family).Null().Length(0).WithMessage("نام خانوادگی اجباری می باشد").
                                 MaximumLength(60).WithMessage(Messages.General.MaximumLength);
        }
    }
}
