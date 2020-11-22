using Microsoft.EntityFrameworkCore;
using ReHomeVirtualBackEnd.General.General.Persistence.Context;
using ReHomeVirtualBackEnd.General.Repositories;
using ReHomeVirtualBackEnd.Initialization.Domain.Model;
using ReHomeVirtualBackEnd.Initialization.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Initialization.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public void DeleteAsync(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<User> FindById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task SaveAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public void UpdateAsync(User user)
        {
            _context.Users.Update(user);
        }
    }
}
