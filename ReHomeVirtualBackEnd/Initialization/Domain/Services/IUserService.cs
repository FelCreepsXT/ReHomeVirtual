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
        Task<IEnumerable<User>> ListAsync();
        Task<PlanResponse> SaveAsync(User plan);
        Task<PlanResponse> DeleteAsync(int id);
        Task<PlanResponse> UpdateAsync(int id, User plan);
    }
}
