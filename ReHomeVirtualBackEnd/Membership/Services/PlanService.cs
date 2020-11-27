using ReHomeVirtualBackEnd.General.Domain.Repositories;
using ReHomeVirtualBackEnd.Membership.Domain.Model;
using ReHomeVirtualBackEnd.Membership.Domain.Repositories;
using ReHomeVirtualBackEnd.Membership.Domain.Services;
using ReHomeVirtualBackEnd.Membership.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Membership.Services
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;
        private readonly IUnitOfWork _unitOfWork;

        public async Task<PlanResponse> DeleteAsync(int id)
        {
            var existingPlan = await _planRepository.FindById(id);
            if (existingPlan == null)
                return new PlanResponse("Plan not found");

            try
            {
                _planRepository.Remove(existingPlan);
                await _unitOfWork.CompleteAsync();
                return new PlanResponse(existingPlan);
            }
            catch (Exception e)
            {
                return new PlanResponse($"An error ocurred while deleting plan: {e.Message}");
            }
        }

     
        public async Task<IEnumerable<Plan>> ListAsync()
        {
            return await _planRepository.ListAsync();
        }

        public async Task<PlanResponse> SaveAsync(Plan plan)
        {
            try
            {
                await _planRepository.SaveAsync(plan);
                await _unitOfWork.CompleteAsync();
                return new PlanResponse(plan);
            }
            catch (Exception e)
            {
                return new PlanResponse($"An error ocurred while saving plan: {e.Message}");
            }
        }

        public async Task<PlanResponse> UpdateAsync(int id, Plan plan)
        {
            var existingPlan = await _planRepository.FindById(id);
            if (existingPlan == null)
                return new PlanResponse("Plan not found");

            try
            {
                _planRepository.Update(existingPlan);
                await _unitOfWork.CompleteAsync();
                return new PlanResponse(existingPlan);
            }
            catch (Exception e)
            {
                return new PlanResponse($"An error ocurred while updating plan: {e.Message}");
            }
        }
    }
}
