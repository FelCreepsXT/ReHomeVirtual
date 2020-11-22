using ReHomeVirtualBackEnd.Hypersetivity.Domain.Model;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Hypersetivity.Domain.Services
{
    public interface IAllergyUserService
    {
        Task<IEnumerable<AllergyUser>> ListAsync();
        Task<IEnumerable<AllergyUser>> ListAsyncByCustomerId(int customerId);
        Task<AllergyUserResponse> SaveAsync(AllergyUser allergyUser);
        Task<AllergyUserResponse> RemoveAsync(int userId, int allergyId);
        Task<AllergyUserResponse> UpdateAsync(int userId, int allergyId, AllergyUser allergyUser);
    }
}
