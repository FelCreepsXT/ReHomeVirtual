using ReHomeVirtualBackEnd.Membership.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Membership.Domain.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> ListAsync();
        Task<Subscription> FindById(int id);
        Task SaveAsync(Subscription subscription);
        void UpdateAsync(Subscription subscription);
        void RemoveAsync(Subscription subscription);
    }
}
