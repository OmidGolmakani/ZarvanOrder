using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Data.DbContext;
using ZarvanOrder.Extensions.Other;
using ZarvanOrder.Interfaces.Repositores;
using ZarvanOrder.Model.Dtos.Requests.Users;
using ZarvanOrder.Model.Entites;

namespace ZarvanOrder.Repositores
{
    public class UserRepository : Repository<Model.Entites.User>
    {
        private readonly DbFactory _dbFactory;
        private readonly UserManager<Model.Entites.User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly Mapper _mapper;

        public UserRepository(DbFactory dbFactory,
                              UserManager<Model.Entites.User> userManager,
                              SignInManager<Model.Entites.User> signInManager,
                              Mapper mapper)
            : base(dbFactory)
        {
            _dbFactory = dbFactory;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._mapper = mapper;
        }

        public override Model.Entites.User Add(Model.Entites.User entity)
        {
            var Result = _userManager.CreateAsync(entity).Result;
            if (Result.Succeeded)
            {
                return entity;
            }
            throw new CustomException.MyException().ToJson(new CustomException.Error()
            {
                Code = Result.Errors.FirstOrDefault().Code,
                Description = Result.Errors.FirstOrDefault().Description
            });
        }

        public Task<IQueryable<Model.Entites.User>> Get(GetUsersRequest request, bool includeDeleted = false)
        {
            return Task.Run(() => this.List(u =>
                                     string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(u.Name) || u.Name.Contains(request.Name) &&
                                     string.IsNullOrEmpty(request.PhoneNUmber) || string.IsNullOrEmpty(u.PhoneNumber) || u.Name.Contains(request.PhoneNUmber) &&
                                     string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(u.Email) || u.Name.Contains(request.Email) &&
                                     string.IsNullOrEmpty(request.UserName) || u.UserName == request.UserName)
                .Skip(request.PageSize * request.PageIndex).Take(request.PageSize));
        }

        public Task<Model.Entites.User> GetById(GetUserRequest request, bool includeDeleted = false)
        {
            return this.DbSet
                 .Where(u => u.Id == request.Id)
                 .AsNoTracking()
                 .FirstOrDefaultAsync();
        }

        public async Task<IList<string>> GetRolesAsync(GetUserRequest request)
        {
            var user = _mapper.Map<Model.Entites.User>(GetById(request));
            if (user == null) throw new NullReferenceException(Model.Messages.General.UserNotFound);
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<SignInResult> SigninAsync(LoginRequst requst)
        {
            var user = await _userManager.FindByNameAsync(requst.UserName);
            if (user == null) throw new NullReferenceException(Model.Messages.General.UserNotFound);
            return await _signInManager.PasswordSignInAsync(requst.UserName, requst.Password, requst.isPersistent, false);
        }

        public async Task SignoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<IdentityResult> AddUserToRoleAsync(GetUserRequest request,string Role)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null) throw new NullReferenceException(Model.Messages.General.UserNotFound);
            return await _userManager.AddToRoleAsync(user, Role);
        }
        public override Model.Entites.User Update(Model.Entites.User entity)
        {
            var Result = _userManager.UpdateAsync(entity).Result;
            if (Result.Succeeded)
            {
                return entity;
            }
            throw new CustomException.MyException().ToJson(new CustomException.Error()
            {
                Code = Result.Errors.FirstOrDefault().Code,
                Description = Result.Errors.FirstOrDefault().Description
            });
        }

        public async Task<bool> IsUniqueUserAsync(UniqueUserValidationRequst requst)
        {
            var user = await _userManager.FindByNameAsync(requst.UserName);
            return user == null ? true : false;
        }

        public async Task<bool> IsUniqueEmailAsync(UniqueEmailValodationRequest requst)
        {
            var user = await _userManager.FindByEmailAsync(requst.Email);
            return user == null ? true : false;
        }

        public async Task<bool> IsUniquePhoneNumberAsync(UniquePhoneNumber requst)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == requst.PhoneNumber);
            return user == null ? true : false;
        }
    }
}
