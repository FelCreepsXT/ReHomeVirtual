using Microsoft.EntityFrameworkCore;
using ReHomeVirtualBackEnd.General.General.Persistence.Context;
using ReHomeVirtualBackEnd.General.Repositories;
using ReHomeVirtualBackEnd.Routines.Domain.Model;
using ReHomeVirtualBackEnd.Routines.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Routines.Persistence.Repositories
{
    public class DietRepository : BaseRepository, IDietRepository
    {
        public DietRepository(AppDbContext context) : base(context)
        {
        }

        public void DeleteAsync(Diet diet)
        {
            _context.Diets.Remove(diet);
        }

        public async Task<Diet> FindById(int id)
        {
            return await _context.Diets.FindAsync(id);
        }

        public async Task<IEnumerable<Diet>> ListAsync()
        {
            return await _context.Diets.ToListAsync();
        }

        public async Task SaveAsync(Diet diet)
        {
            await _context.Diets.AddAsync(diet);
        }

        public void UpdateAsync(Diet diet)
        {
            _context.Diets.Update(diet);
        }
    }
}
