using ReHomeVirtualBackEnd.Membership.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Membership.Domain.Repositories
{
    public interface IPlanRepository
    {
        Task<IEnumerable<Plan>> ListAsync();
        Task SaveAsync(Plan plan);
        Task<Plan> FindById(int id);
       
        void Update(Plan plan);
        void Remove(Plan plan);
    }
}
