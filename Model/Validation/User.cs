﻿using AutoMapper;
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
        private readonly Mapper _mapper;

        internal User(IUserService userService,
                      Mapper mapper)
        {
            this._userService = userService;
            _mapper = mapper;
            RuleFor(p => p.Id).NotNull().WithMessage("آی دی اجباری می باشد");
            RuleFor(p => p.Name).NotNull().Length(0).WithMessage("نام اجباری می باشد").
                                 MaximumLength(60).WithMessage(Messages.General.MaximumLength);
            RuleFor(p => p.Family).NotNull().Length(0).WithMessage("نام خانوادگی اجباری می باشد").
                                   MaximumLength(60).WithMessage(Messages.General.MaximumLength);

            RuleFor(p => p).NotEmpty().NotNull().WithMessage("نام کاربری اجباری می باشد").
                            MustAsync((p, cancellation) => IsUniqueUserNameAsync(p)).WithMessage("نام کاربری تکراری می باشد");

            RuleFor(p => p).NotEmpty().NotNull().WithMessage("تلفن همراه اجباری می باشد").
                            MustAsync((p, cancellation) => IsUniquePhoneNumberAsync(p)).WithMessage("تلغن همراه تکراری می باشد");

            RuleFor(p => p).MustAsync((p, cancellation) => IsUniqueEmailAsync(p)).WithMessage("پست الکترونیک تکراری می باشد");

            RuleFor(p => p).Must(IsUniqueNationalCodeAsync).WithMessage("کد ملی غیر مجاز می باشد");

        }
        internal async Task<bool> IsUniqueUserNameAsync(Entites.User request)
        {
            Dtos.Requests.Users.UniqueUser _request = new Dtos.Requests.Users.UniqueUser();
            _mapper.Map<Entites.User, Dtos.Requests.Users.UniqueUser>(request, _request);
            return await _userService.IsUniqueUserAsync(_request);
        }
        internal async Task<bool> IsUniquePhoneNumberAsync(Entites.User request)
        {
            Dtos.Requests.Users.UniquePhoneNumber _request = new Dtos.Requests.Users.UniquePhoneNumber();
            _mapper.Map<Entites.User, Dtos.Requests.Users.UniquePhoneNumber>(request, _request);
            return await _userService.IsUniquePhoneNumberAsync(_request);
        }
        internal async Task<bool> IsUniqueEmailAsync(Entites.User request)
        {
            Dtos.Requests.Users.UniqueEmail _request = new Dtos.Requests.Users.UniqueEmail();
            _mapper.Map<Entites.User, Dtos.Requests.Users.UniqueEmail>(request, _request);
            return await _userService.IsUniqueEmailAsync(_request);
        }
        internal bool IsUniqueNationalCodeAsync(Entites.User request)
        {
            return request.NationalCode.Length <= 0 || request.NationalCode.Length == 10 ? true : false;
        }

    }
}