using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Interfaces.DataServices;
using ZarvanOrder.Interfaces.Repositores;
using ZarvanOrder.Model.Dtos.Requests.Users;
using ZarvanOrder.Model.Dtos.Responses.Pageing;
using ZarvanOrder.Model.Dtos.Responses.Users;
using ZarvanOrder.Model.Validation;

namespace ZarvanOrder.Services.Data
{
    public class UserService : IService<AddUserRequest, EditUserRequest, GetUserRequest, UserResponse>,
                               IGetService<GetUserRequest, GetUsersRequest, UserResponse>,
                               IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;
        private readonly UserValidation userValidation;


        public UserService(IUserRepository userRepository,
                           IUnitOfWork unitOfWork,
                           Mapper mapper,
                           UserValidation userValidation)
        {
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this.userValidation = userValidation;
        }

        public async Task<UserResponse> Add(AddUserRequest request)
        {
            var entity = _mapper.Map<Model.Entites.User>(request);
            _userRepository.Add(entity);
            return _mapper.Map<UserResponse>(entity);
        }

        public Task<List<IdentityResult>> AddUserToRole(AddUserToRoleRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponse> BatchDelete(IEnumerable<GetUserRequest> request)
        {
            throw new NotImplementedException();
        }

        public Task BatchUpdate(IEnumerable<GetUserRequest> request)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(GetUsersRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponse> Delete(GetUserRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ListResponse<UserResponse>> GetAsync(GetUserRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ListResponse<UserResponse>> GetsAsync(GetUsersRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetUserRoles(GetUserRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUniqueEmailAsync(UniqueEmailValodationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUniquePhoneNumberAsync(UniquePhoneNumber request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUniqueUserAsync(UniqueUserValidationRequst request)
        {
            throw new NotImplementedException();
        }

        public Task<string> PhoneNumberConfirmation(string PhoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<SigninResponse> SignIn(LoginRequst request)
        {
            throw new NotImplementedException();
        }

        public Task SignOut()
        {
            throw new NotImplementedException();
        }

        public Task<UserResponse> Update(EditUserRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> VerifyPhoneNumber(string PhoneNumber, string Token)
        {
            throw new NotImplementedException();
        }
    }
}
