using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZarvanOrder.Interfaces.DataServices;

namespace ZarvanOrder.Model.Validation
{
    internal class User : AbstractValidator<Entites.User>
    {
        private readonly IUserService _userService;

        internal User(IUserService userService)
        {
            this._userService = userService;
            RuleFor(p => p.Id).NotNull().WithMessage("آی دی اجباری می باشد");
            RuleFor(p => p.Name).NotNull().Length(0).WithMessage("نام اجباری می باشد").
                                 MaximumLength(60).WithMessage(Messages.General.MaximumLength);
            RuleFor(p => p.Family).NotNull().Length(0).WithMessage("نام خانوادگی اجباری می باشد").
                                 MaximumLength(60).WithMessage(Messages.General.MaximumLength);
            RuleFor(p => p.UserName).MustAsync((p, cancellation) => IsUniqueUserName(p)).WithMessage("نام کاربری تکراری می باشد");
        }
        internal async Task<bool> IsUniqueUserName(string request)
        {
            return await _userService.IsUniqueUserAsync(new Dtos.Requests.Users.IsUniqueUser()
            {
                UserName = request
            });
        }

    }
}
