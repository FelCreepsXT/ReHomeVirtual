using ReHomeVirtualBackEnd.Membership.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Membership.Domain.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> ListAsync();

        Task<IEnumerable<Subscription>> ListByUserIdAsync(int userId);

        Task AddAsync(Subscription subscription);
        Task<Subscription> FindById(int userId);
        
        void Update(Subscription subscription);
        void Remove(Subscription subscription);
    }
}
