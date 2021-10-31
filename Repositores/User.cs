using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
    public class User : Repository<User>, IUserRepository
    {
        private readonly DbFactory _dbFactory;
        private readonly UserManager<Model.Entites.User> _userManager;
        private readonly Mapper _mapper;

        public User(DbFactory dbFactory,
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

        public Task<int> Count(GetUsers request, bool includeDeleted = false)
        {
            throw new NotImplementedException();
        }

        public Model.Entites.User Delete(Model.Entites.User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Model.Entites.User>> Get(GetUsers request, bool includeDeleted = false)
        {
            throw new NotImplementedException();
        }

        public Task<Model.Entites.User> GetById(GetUser request, bool includeDeleted = false)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Model.Entites.User> List(Expression<Func<Model.Entites.User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Model.Entites.User Update(Model.Entites.User entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateBatch(IEnumerable<Model.Entites.User> entity)
        {
            throw new NotImplementedException();
        }
    }
}
