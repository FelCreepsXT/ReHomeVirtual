using ReHomeVirtualBackEnd.Initialization.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Initialization.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task<User> FindById(int id);
        Task SaveAsync(User plan);
        void DeleteAsync(User plan);
        void UpdateAsync(User plan);
    }
}
