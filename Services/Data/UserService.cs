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
    public class UserService : IService<AddUserRequest, EditUserRequest,DeleteUserRequest, UserResponse>,
                               IGetService<GetUserRequest, GetUsersRequest, UserResponse>,
                               IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public UserService(IUserRepository userRepository,
                           IUnitOfWork unitOfWork,
                           IMapper mapper)
        {
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public Task<UserResponse> Add(AddUserRequest request)
        {
            var entity = _mapper.Map<Model.Entites.User>(request);
            _userRepository.Add(entity);
            _unitOfWork.CommitAsync();
            return Task.Run(() => _mapper.Map<UserResponse>(entity));
        }

        public Task<List<IdentityResult>> AddUserToRole(AddUserToRoleRequest request)
        {
            throw new NotImplementedException();
        }

        public Task BatchDelete(IEnumerable<DeleteUserRequest> request)
        {
            var entites = _mapper.Map<IEnumerable<Model.Entites.User>>(request);
            _userRepository.DeleteBatch(entites);
            _unitOfWork.CommitAsync();
            return Task.Run(() => true);
        }

        public Task BatchUpdate(IEnumerable<EditUserRequest> request)
        {
            var entites = _mapper.Map<IEnumerable<Model.Entites.User>>(request);
            _userRepository.UpdateBatch(entites);
            _unitOfWork.CommitAsync();
            return Task.Run(() => true);
        }

        public async Task<int> CountAsync(GetUsersRequest request)
        {
            var Count = await _userRepository.Get(request);
            return Count.Count();
        }

        public Task Delete(DeleteUserRequest request)
        {
            var entity = _mapper.Map<Model.Entites.User>(request);
            _userRepository.Delete(entity);
            _unitOfWork.CommitAsync();
            var model = new UserResponse();
            return Task.Run(() => _mapper.Map<Model.Entites.User, UserResponse>(entity, model));
        }

        public async Task<UserResponse> GetAsync(GetUserRequest request)
        {
            return _mapper.Map<UserResponse>(await _userRepository.GetById(request));
        }

        public async Task<ListResponse<UserResponse>> GetsAsync(GetUsersRequest request)
        {
            var items = _mapper.Map<IEnumerable<UserResponse>>(await _userRepository.Get(request));
            return new ListResponse<UserResponse>() { Items = items, Total = items.Count() };
        }

        public Task<IList<string>> GetUserRolesAsync(GetUserRequest request)
        {
            return _userRepository.GetRolesAsync(request);
        }

        public async Task<bool> IsUniqueEmailAsync(UniqueEmailValodationRequest request)
        {
            return await _userRepository.IsUniqueEmailAsync(request);
        }

        public Task<bool> IsUniquePhoneNumberAsync(UniquePhoneNumber request)
        {
            return _userRepository.IsUniquePhoneNumberAsync(request);
        }

        public async Task<bool> IsUniqueUserAsync(UniqueUserValidationRequst request)
        {
            return await _userRepository.IsUniqueUserAsync(request);
        }

        public Task<string> PhoneNumberConfirmation(string PhoneNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<SignInResult> SignInAsync(LoginRequst request)
        {
            return await _userRepository.SigninAsync(request);
        }

        public async Task SignoutAsync()
        {
            await _userRepository.SignoutAsync();
        }

        public Task<UserResponse> Update(EditUserRequest request)
        {
            var entity = _mapper.Map<Model.Entites.User>(request);
            _userRepository.Update(entity);
            var model = new UserResponse();
            return Task.Run(() => _mapper.Map<Model.Entites.User, UserResponse>(entity, model));
        }

        public Task<IdentityResult> VerifyPhoneNumber(string PhoneNumber, string Token)
        {
            throw new NotImplementedException();
        }

    }
}
