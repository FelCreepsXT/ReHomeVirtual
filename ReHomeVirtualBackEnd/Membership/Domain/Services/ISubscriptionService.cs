using ReHomeVirtualBackEnd.Membership.Domain.Model;
using ReHomeVirtualBackEnd.Membership.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Membership.Domain.Services
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<Subscription>> ListAsync();
        Task<SubscriptionResponse> FindById(int id);
        Task<SubscriptionResponse> SaveAsync(Subscription subscription);
        Task<SubscriptionResponse> UpdateAsync(int id, Subscription subscription);
        Task<SubscriptionResponse> DeleteAsync(int id);
    }
}
