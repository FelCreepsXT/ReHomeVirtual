using ReHomeVirtualBackEnd.Membership.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Membership.Domain.Repositories
{
    public interface IPlanRepository
    {
        Task<IEnumerable<Plan>> ListAsync();
        Task<Plan> FindById(int id);
        Task SaveAsync(Plan plan);
        void DeleteAsync(Plan plan);
        void UpdateAsync(Plan plan);
    }
}
