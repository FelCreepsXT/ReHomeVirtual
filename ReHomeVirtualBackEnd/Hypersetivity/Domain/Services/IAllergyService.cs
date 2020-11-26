using ReHomeVirtualBackEnd.Hypersetivity.Domain.Model;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Services.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Hypersetivity.Domain.Services.Communications
{
    public interface IAllergyService
    {
        Task<IEnumerable<Allergy>> ListAsync();
        Task<AllergyResponse> SaveAsync(Allergy allergy);
        Task<AllergyResponse> DeleteAsync(int id);
        Task<AllergyResponse> UpdateAsync(int id, Allergy allergy);
    }
}
