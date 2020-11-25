using ReHomeVirtualBackEnd.General.Domain.Repositories;
using ReHomeVirtualBackEnd.Initialization.Domain.Model;
using ReHomeVirtualBackEnd.Initialization.Domain.Repositories;
using ReHomeVirtualBackEnd.Initialization.Domain.Services.Communications;
using ReHomeVirtualBackEnd.Initialization.Domain.Services.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Initialization.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        public readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var existingRole = await _userRepository.FindById(id);

            if (existingRole == null)
                return new UserResponse("Role not found");
            return new UserResponse(existingRole);
        }


        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while saving role: {ex.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            var existingRole = await _userRepository.FindById(id);
            if (existingRole == null)
                return new UserResponse("Role not found");

            existingRole.Name = user.Name;

            try
            {
                _userRepository.Update(existingRole);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingRole);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while updating role: {ex.Message}");
            }
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingUser = await _userRepository.FindById(id);

            if (existingUser == null)
                return new UserResponse("Role not found");

            try
            {
                _userRepository.Remove(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while deleting role: {ex.Message}");
            }
        }
    
    }
}
