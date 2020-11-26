using ReHomeVirtualBackEnd.General.Domain.Repositories;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Model;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Repositories;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Services.Communications;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Services.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Hypersetivity.Services
{
    public class AllergyService : IAllergyService
    {
        private readonly IAllergyRepository _allergyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AllergyService(IAllergyRepository allergyRepository, IUnitOfWork unitOfWork)
        {
            _allergyRepository = allergyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AllergyResponse> DeleteAsync(int id)
        {
            var existingPlan = await _allergyRepository.FindById(id);
            if (existingPlan == null)
                return new AllergyResponse("Plan not found");

            try
            {
                _allergyRepository.DeleteAsync(existingPlan);
                await _unitOfWork.CompleteAsync();
                return new AllergyResponse(existingPlan);
            }
            catch (Exception e)
            {
                return new AllergyResponse($"An error ocurred while deleting plan: {e.Message}");
            }
        }

        public async Task<IEnumerable<Allergy>> ListAsync()
        {
            return await _allergyRepository.ListAsync();
        }

        public async Task<AllergyResponse> SaveAsync(Allergy allergy)
        {
            try
            {
                await _allergyRepository.SaveAsync(allergy);
                await _unitOfWork.CompleteAsync();
                return new AllergyResponse(allergy);
            }
            catch (Exception e)
            {
                return new AllergyResponse($"An error ocurred while saving plan: {e.Message}");
            }
        }

        public async Task<AllergyResponse> UpdateAsync(int id, Allergy allergy)
        {
            var existingPlan = await _allergyRepository.FindById(id);
            if (existingPlan == null)
                return new AllergyResponse("Plan not found");

            try
            {
                _allergyRepository.UpdateAsync(existingPlan);
                await _unitOfWork.CompleteAsync();
                return new AllergyResponse(existingPlan);
            }
            catch (Exception e)
            {
                return new AllergyResponse($"An error ocurred while updating plan: {e.Message}");
            }
        }
    }
}
