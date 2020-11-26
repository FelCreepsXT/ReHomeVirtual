using ReHomeVirtualBackEnd.Membership.Domain.Model;
using ReHomeVirtualBackEnd.Membership.Domain.Services.Communications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Membership.Domain.Services
{
    public interface IPlanService
    {
        Task<IEnumerable<Plan>> ListAsync();
        Task<PlanResponse> SaveAsync(Plan plan);
        Task<PlanResponse> DeleteAsync(int id);
        Task<PlanResponse> UpdateAsync(int id, Plan plan);
    }
}
