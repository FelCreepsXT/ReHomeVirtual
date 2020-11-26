using ReHomeVirtualBackEnd.Routines.Domain.Model;
using ReHomeVirtualBackEnd.Routines.Domain.Services.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Routines.Domain.Services
{
    public interface IDietService
    {
        Task<IEnumerable<Diet>> ListAsync();
        Task<DietResponse> SaveAsync(Diet diet);
        Task<DietResponse> DeleteAsync(int id);
        Task<DietResponse> UpdateAsync(int id, Diet diet);
    }
}
