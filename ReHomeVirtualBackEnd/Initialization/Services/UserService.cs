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
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingPlan = await _userRepository.FindById(id);
            if (existingPlan == null)
                return new UserResponse("User not found");

            try
            {
                _userRepository.DeleteAsync(existingPlan);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(existingPlan);
            }
            catch(Exception e)
            {
                return new UserResponse($"An error ocurred while deleting plan: {e.Message}");
            }
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<UserResponse> SaveAsync(User plan)
        {
            try
            {
                await _userRepository.SaveAsync(plan);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(plan);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error ocurred while saving plan: {e.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int id, User plan)
        {
            var existingPlan = await _userRepository.FindById(id);
            if (existingPlan == null)
                return new UserResponse("Plan not found");

            try
            {
                _userRepository.UpdateAsync(existingPlan);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(existingPlan);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error ocurred while updating plan: {e.Message}");
            }
        }
    }
}
