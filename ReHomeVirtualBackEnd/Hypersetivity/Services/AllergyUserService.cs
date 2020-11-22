using ReHomeVirtualBackEnd.General.Domain.Repositories;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Model;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Repositories;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Services;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Services.Communications;
using ReHomeVirtualBackEnd.Initialization.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Hypersetivity.Services
{
    public class AllergyUserService : IAllergyUserService
    {
        private readonly IAllergyUserRepository _allergyUserRepository;
        private readonly IAllergyRepository _allergyRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AllergyUserService(IAllergyUserRepository allergyUserRepository, IAllergyRepository allergyRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _allergyUserRepository = allergyUserRepository;
            _allergyRepository = allergyRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AllergyUser>> ListAsync()
        {
            return await _allergyUserRepository.ListAsync();
        }

        public async Task<IEnumerable<AllergyUser>> ListAsyncByCustomerId(int customerId)
        {
            return await _allergyUserRepository.ListAsyncByCustomerId(customerId);
        }

        public async Task<AllergyUserResponse> RemoveAsync(int userId, int allergyId)
        {
            var existingAllergyUser = await _allergyUserRepository.FindByUserIdAndAllergyId(userId, allergyId);
            if (existingAllergyUser  == null)
                return new AllergyUserResponse("AllergyUser not found");
            try
            {
                _allergyUserRepository.RemoveAsync(existingAllergyUser);
                await _unitOfWork.CompleteAsync();
                return new AllergyUserResponse(existingAllergyUser);
            }
            catch(Exception e)
            {
                return new AllergyUserResponse($"An error ocurred while deleting the AllergyUser: {e.Message}");
            }
        }

        public async Task<AllergyUserResponse> SaveAsync(AllergyUser allergyUser)
        {
            var existingAllergy = await _allergyRepository.FindById(allergyUser.AllergyId);
            if (existingAllergy == null)
                return new AllergyUserResponse("Allergy not found");

            var existingUser = await _userRepository.FindById(allergyUser.UserId);
            if (existingUser == null)
                return new AllergyUserResponse("User not found");

            allergyUser.Allergy = existingAllergy;
            allergyUser.User = existingUser;
            try
            {
                await _allergyUserRepository.SaveAsync(allergyUser);
                await _unitOfWork.CompleteAsync();
                return new AllergyUserResponse(allergyUser);
            }
            catch (Exception e)
            {
                return new AllergyUserResponse($"An error ocurred while saving the AllergyUser: {e.Message}");
            }
        }

        public async Task<AllergyUserResponse> UpdateAsync(int userId, int allergyId, AllergyUser allergyUser)
        {
            var existingAllergyUser = await _allergyUserRepository.FindByUserIdAndAllergyId(userId, allergyId);
            if (existingAllergyUser == null)
                return new AllergyUserResponse("AllergyUser not found");
            try
            {
                _allergyUserRepository.UpdateAsync(existingAllergyUser);
                await _unitOfWork.CompleteAsync();
                return new AllergyUserResponse(existingAllergyUser);
            }
            catch (Exception e)
            {
                return new AllergyUserResponse($"An error ocurred while deleting the AllergyUser: {e.Message}");
            }
        }
    }
}
