using ReHomeVirtualBackEnd.Hypersetivity.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Hypersetivity.Domain.Repositories
{
    public interface IAllergyUserRepository
    {
        Task<IEnumerable<AllergyUser>> ListAsync();
        Task<IEnumerable<AllergyUser>> ListAsyncByCustomerId(int customerId);
        Task<AllergyUser> FindByUserIdAndAllergyId(int userId, int allergyId);
        Task SaveAsync(AllergyUser allergyUser);
        void RemoveAsync(AllergyUser allergyUser);
        void UpdateAsync(AllergyUser allergyUser);
    }
}
