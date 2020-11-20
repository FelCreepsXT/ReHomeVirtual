using ReHomeVirtualBackEnd.Hypersetivity.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Hypersetivity.Domain.Repositories
{
    public interface IAllergyRepository
    {
        Task<IEnumerable<Allergy>> ListAsync();
        Task<Allergy> FindById(int id);
        Task SaveAsync(Allergy allergy);
        void DeleteAsync(Allergy allergy);
        void UpdateAsync(Allergy allergy);
    }
}
