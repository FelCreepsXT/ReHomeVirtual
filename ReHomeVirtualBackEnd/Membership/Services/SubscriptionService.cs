using ReHomeVirtualBackEnd.General.Domain.Repositories;
using ReHomeVirtualBackEnd.Initialization.Domain.Repositories;
using ReHomeVirtualBackEnd.Membership.Domain.Model;
using ReHomeVirtualBackEnd.Membership.Domain.Repositories;
using ReHomeVirtualBackEnd.Membership.Domain.Services;
using ReHomeVirtualBackEnd.Membership.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Membership.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPlanRepository _planRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SubscriptionService(IUserRepository userRepository, IPlanRepository planRepository, ISubscriptionRepository subscriptionRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _planRepository = planRepository;
            _subscriptionRepository = subscriptionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SubscriptionResponse> FindById(int id)
        {
            var existingSubscription = await _subscriptionRepository.FindById(id);
            if (existingSubscription == null)
                return new SubscriptionResponse("Subscription not found");
            return new SubscriptionResponse(existingSubscription);
        }

        public async Task<IEnumerable<Subscription>> ListAsync()
        {
            return await _subscriptionRepository.ListAsync();
        }

        public async Task<SubscriptionResponse> DeleteAsync(int id)
        {
            var existingSubscription = await _subscriptionRepository.FindById(id);
            if (existingSubscription == null)
                return new SubscriptionResponse("Subscription not found");
            try
            {
                _subscriptionRepository.RemoveAsync(existingSubscription);
                await _unitOfWork.CompleteAsync();
                return new SubscriptionResponse(existingSubscription);
            }
            catch (Exception e)
            {
                return new SubscriptionResponse($"An error ocurred while deleting the Subscription: {e.Message}");
            }
        }

        public async Task<SubscriptionResponse> SaveAsync(Subscription subscription)
        {
            var existingUser = await _userRepository.FindById(subscription.UserId);
            if (existingUser == null)
                return new SubscriptionResponse("User not found");

            var existingPlan = await _planRepository.FindById(subscription.PlanId);
            if (existingPlan == null)
                return new SubscriptionResponse("Plan not found");

            subscription.Plan = existingPlan;
            subscription.User = existingUser;
            try
            {
                await _subscriptionRepository.SaveAsync(subscription);
                await _unitOfWork.CompleteAsync();
                return new SubscriptionResponse(subscription);
            }
            catch (Exception e)
            {
                return new SubscriptionResponse($"An error ocurred while saving the Subscription: {e.Message}");
            }
        }

        public async Task<SubscriptionResponse> UpdateAsync(int id, Subscription subscription)
        {
            var existingSubscription = await _subscriptionRepository.FindById(id);
            if (existingSubscription == null)
                return new SubscriptionResponse("Subscription not found");
            try
            {
                _subscriptionRepository.UpdateAsync(existingSubscription);
                await _unitOfWork.CompleteAsync();
                return new SubscriptionResponse(existingSubscription);
            }
            catch (Exception e)
            {
                return new SubscriptionResponse($"An error ocurred while deleting the Subscription: {e.Message}");
            }
        }
    }
}
