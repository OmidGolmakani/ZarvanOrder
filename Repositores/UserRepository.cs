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

namespace ZarvanOrder.Repositores
{
    public class UserRepository : Repository<Model.Entites.User>, IUserRepository
    {
        private readonly DbFactory _dbFactory;
        private readonly UserManager<Model.Entites.User> _userManager;
        private readonly Mapper _mapper;

        public UserRepository(DbFactory dbFactory,
                    Microsoft.AspNetCore.Identity.UserManager<Model.Entites.User> userManager) : base(dbFactory)
        {
            _dbFactory = dbFactory;
            this._userManager = userManager;
        }

        public Model.Entites.User Add(Model.Entites.User entity)
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

        public async Task<IQueryable<Model.Entites.User>> Get(GetUsersRequest request, bool includeDeleted = false)
        {
            return this.List(u =>
                                   string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(u.Name) || u.Name.Contains(request.Name) &&
                                   string.IsNullOrEmpty(request.PhoneNUmber) || string.IsNullOrEmpty(u.PhoneNumber) || u.Name.Contains(request.PhoneNUmber) &&
                                   string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(u.Email) || u.Name.Contains(request.Email) &&
                                   string.IsNullOrEmpty(request.UserName) || u.UserName == request.UserName)
                .Skip(request.PageSize * request.PageIndex).Take(request.PageSize);
        }

        public Task<Model.Entites.User> GetById(GetUserRequest request, bool includeDeleted = false)
        {
            return this.DbSet
                 .Where(u => u.Id == request.Id)
                 .AsNoTracking()
                 .FirstOrDefaultAsync();
        }
        public Model.Entites.User Update(Model.Entites.User entity)
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
    }
}
