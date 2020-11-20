using ReHomeVirtualBackEnd.Membership.Domain.Model;
using ReHomeVirtualBackEnd.Membership.Domain.Services.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Membership.Domain.Services.Communications
{
    public interface IPlanService
    {
        Task<IEnumerable<Plan>> ListAsync();
        Task<PlanResponse> SaveAsync(Plan plan);
        Task<PlanResponse> DeleteAsync(int id);
        Task<PlanResponse> UpdateAsync(int id, Plan plan);
    }
}
