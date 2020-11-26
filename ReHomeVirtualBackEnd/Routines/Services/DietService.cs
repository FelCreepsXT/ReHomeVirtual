using ReHomeVirtualBackEnd.General.Domain.Repositories;
using ReHomeVirtualBackEnd.Routines.Domain.Model;
using ReHomeVirtualBackEnd.Routines.Domain.Repositories;
using ReHomeVirtualBackEnd.Routines.Domain.Services;
using ReHomeVirtualBackEnd.Routines.Domain.Services.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Routines.Services
{
    public class DietService : IDietService
    {
        private readonly IDietRepository _dietRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DietService(IDietRepository dietRepository, IUnitOfWork unitOfWork)
        {
            _dietRepository = dietRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DietResponse> DeleteAsync(int id)
        {
            var existingDiet = await _dietRepository.FindById(id);
            if (existingDiet == null)
                return new DietResponse("Diet not found");

            try
            {
                _dietRepository.DeleteAsync(existingDiet);
                await _unitOfWork.CompleteAsync();
                return new DietResponse(existingDiet);
            }
            catch (Exception e)
            {
                return new DietResponse($"An error ocurred while deleting Diet: {e.Message}");
            }
        }

        public async Task<IEnumerable<Diet>> ListAsync()
        {
            return await _dietRepository.ListAsync();
        }

        public async Task<DietResponse> SaveAsync(Diet diet)
        {
            try
            {
                await _dietRepository.SaveAsync(diet);
                await _unitOfWork.CompleteAsync();
                return new DietResponse(diet);
            }
            catch (Exception e)
            {
                return new DietResponse($"An error ocurred while saving Diet: {e.Message}");
            }
        }

        public async Task<DietResponse> UpdateAsync(int id, Diet diet)
        {
            var existingDiet = await _dietRepository.FindById(id);
            if (existingDiet == null)
                return new DietResponse("Diet not found");

            try
            {
                _dietRepository.UpdateAsync(existingDiet);
                await _unitOfWork.CompleteAsync();
                return new DietResponse(existingDiet);
            }
            catch (Exception e)
            {
                return new DietResponse($"An error ocurred while updating Diet: {e.Message}");
            }
        }
    }
}
