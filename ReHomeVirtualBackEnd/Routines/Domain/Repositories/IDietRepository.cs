using ReHomeVirtualBackEnd.Routines.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Routines.Domain.Repositories
{
    public interface IDietRepository
    {
        Task<IEnumerable<Diet>> ListAsync();
        Task<Diet> FindById(int id);
        Task SaveAsync(Diet diet);
        void DeleteAsync(Diet diet);
        void UpdateAsync(Diet diet);
    }
}
