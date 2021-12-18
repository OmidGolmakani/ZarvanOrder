using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Interfaces.DataServices;

namespace ZarvanOrder.Model.Validation
{
    public class CustomerValidation : AbstractValidator<Entites.Customer>
    {
        private readonly ICustomerService _service;

        public CustomerValidation(ICustomerService service)
        {
            this._service = service;
            RuleFor(p => p.Code).NotNull().WithMessage("کد مشتری اجباری می باشد");
            RuleFor(p => p).MustAsync((p, cancellation) => IsUniqeCodeAsync(p)).WithMessage("کد مشتری تکراری می باشد");
            RuleFor(p => p).Must(IsReqiredCompany).WithMessage("نام شرکت اجباری می باشد");
            RuleFor(p => p).Must(IsReqiredFullName).WithMessage("نام و نام خانوادگی اجباری می باشد");
            RuleFor(p => p.Reminded).LessThan(0).WithMessage("مانده مشتری نمیتواند کوچکتر از صفر باشد");
        }
        private async Task<bool> IsUniqeCodeAsync(Entites.Customer request)
        {
            return await _service.IsUniqueCustomerCode(request.Code);
        }
        private bool IsReqiredCompany(Entites.Customer request)
        {
            if (request.CustomerType == (byte)Enums.Customer.CustomerType.Company)
            {
                return string.IsNullOrEmpty(request.CompanyName) ? true : false;
            }
            return true;
        }
        private bool IsReqiredFullName(Entites.Customer request)
        {
            if (request.CustomerType == (byte)Enums.Customer.CustomerType.Person)
            {
                return string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Family) ? true : false;
            }
            return true;

        }
    }
}
