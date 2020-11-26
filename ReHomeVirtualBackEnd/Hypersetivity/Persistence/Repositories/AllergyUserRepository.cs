using Microsoft.EntityFrameworkCore;
using ReHomeVirtualBackEnd.General.General.Persistence.Context;
using ReHomeVirtualBackEnd.General.Repositories;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Model;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Hypersetivity.Persistence.Repositories
{
    public class AllergyUserRepository : BaseRepository, IAllergyUserRepository
    {
        public AllergyUserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<AllergyUser> FindByUserIdAndAllergyId(int userId, int allergyId)
        {
            return await _context.AllergyUsers
                .Where(p => p.UserId == userId)
                .Where(p => p.AllergyId == allergyId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AllergyUser>> ListAsync()
        {
            return await _context.AllergyUsers.ToListAsync();
        }

        public async Task<IEnumerable<AllergyUser>> ListAsyncByCustomerId(int userId)
        {
            return await _context.AllergyUsers
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        public void RemoveAsync(AllergyUser allergyUser)
        {
            _context.AllergyUsers.Remove(allergyUser);
        }

        public async Task SaveAsync(AllergyUser allergyUser)
        {
            await _context.AllergyUsers.AddAsync(allergyUser);
        }

        public void UpdateAsync(AllergyUser allergyUser)
        {
            _context.AllergyUsers.Update(allergyUser);
        }
    }
}
