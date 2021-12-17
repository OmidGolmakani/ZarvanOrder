using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ZarvanOrder.CustomException;
using ZarvanOrder.Data.DbContext;
using ZarvanOrder.Interfaces.Repositores;
using ZarvanOrder.Model.Dtos.Requests.Users;
using ZarvanOrder.Model.Dtos.Responses.Users;
using ZarvanOrder.Model.Entites;

namespace ZarvanOrder.Repositores
{
    public class UserRepository : Repository<long,Model.Entites.User>, IUserRepository
    {
        private readonly DbFactory _dbFactory;
        private readonly UserManager<Model.Entites.User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public UserRepository(DbFactory dbFactory,
                              UserManager<Model.Entites.User> userManager,
                              SignInManager<Model.Entites.User> signInManager,
                              IMapper mapper)
            : base(dbFactory, mapper)
        {
            _dbFactory = dbFactory;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._mapper = mapper;
        }

        public override Model.Entites.User Add(Model.Entites.User entity)
        {
            var Result = _userManager.CreateAsync(entity, entity.PasswordHash).Result;
            if (Result.Succeeded)
            {
                return entity;
            }
            throw new MyException(-1, Result.Errors.FirstOrDefault().Description);
        }

        public IQueryable<Model.Entites.User> Get(GetUsersRequest request, bool includeDeleted = false)
        {
            return this.List(u =>
                                     string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(u.Name) || u.Name.Contains(request.Name) &&
                                     string.IsNullOrEmpty(request.PhoneNUmber) || string.IsNullOrEmpty(u.PhoneNumber) || u.Name.Contains(request.PhoneNUmber) &&
                                     string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(u.Email) || u.Name.Contains(request.Email) &&
                                     string.IsNullOrEmpty(request.UserName) || u.UserName == request.UserName); 
                //.Skip(request.PageSize * request.PageIndex).Take(request.PageSize).AsQueryable();
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
            if (user == null) throw new MyException((int)HttpStatusCode.NotFound, Model.Messages.General.UserNotFound);
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<SigninResponse> SigninAsync(LoginRequst requst)
        {
            var entity = await _userManager.FindByNameAsync(requst.UserName);
            if (entity == null) throw new MyException((int)HttpStatusCode.OK, Model.Messages.General.UserNotFound);
            var model = _mapper.Map<UserResponse>(entity);
            SignInResult result = await _signInManager.PasswordSignInAsync(requst.UserName, requst.Password, requst.isPersistent, false);
            if (result.Succeeded == false)
            {
                if (entity.PhoneNumberConfirmed == false)
                {
                    throw new MyException((int)HttpStatusCode.InternalServerError, "تلفن همراه تایید نشده است");
                }
                else if (entity.PhoneNumberConfirmed)
                {
                    throw new MyException((int)HttpStatusCode.OK, "رمز عبور اشتباه می باشد");
                }
            }
            return new SigninResponse()
            {
                SignIn = result,
                UserId = model.Id,
                Token = result.Succeeded == false ? null : Helpers.JWTTokenManager.GenerateToken(model, new List<string>()),
                IsAdmin = false
            };
        }

        public async Task SignoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<IdentityResult> AddUserToRoleAsync(GetUserRequest request, string Role)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null) throw new MyException(Model.Messages.General.UserNotFound);
            return await _userManager.AddToRoleAsync(user, Role);
        }
        public override Model.Entites.User Update(Model.Entites.User entity)
        {

            DbSet.Attach(entity);
            var Result = _userManager.UpdateAsync(entity).Result;
            if (Result.Succeeded)
            {
                return entity;
            }
            throw new MyException(-1, Result.Errors.FirstOrDefault().Description);
        }

        public async Task<bool> IsUniqueUserAsync(UniqueUserValidationRequst requst)
        {
            if (requst.UserName == null) return true;
            var user = await _userManager.Users.Where(u => u.Email == requst.UserName).CountAsync();
            return user <= 1 ? true : false;
        }

        public async Task<bool> IsUniqueEmailAsync(UniqueEmailValodationRequest requst)
        {
            if (requst.Email == null) return true;
            var user = await _userManager.Users.Where(u => u.Email == requst.Email).CountAsync();
            return user <= 1 ? true : false;
        }

        public async Task<bool> IsUniquePhoneNumberAsync(UniquePhoneNumber requst)
        {
            if (requst.PhoneNumber == null) return true;
            var user = await _userManager.Users.Where(u => u.PhoneNumber == requst.PhoneNumber).CountAsync();
            return user <= 1 ? true : false;
        }
    }
}
