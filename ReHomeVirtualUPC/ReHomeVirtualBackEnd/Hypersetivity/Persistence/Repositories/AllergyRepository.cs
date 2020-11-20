using Microsoft.EntityFrameworkCore;
using ReHomeVirtualBackEnd.General.General.Persistence.Context;
using ReHomeVirtualBackEnd.General.Repositories;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Model;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Hypersetivity.Persistence.Repositories
{
    public class AllergyRepository : BaseRepository, IAllergyRepository
    {
        public AllergyRepository(AppDbContext context) : base(context)
        {
        }

        public void DeleteAsync(Allergy allergy)
        {
            _context.Plans.Remove(allergy);
        }

        public async Task<Allergy> FindById(int id)
        {
            return await _context.FindAsync(id);
        }

        public async Task<IEnumerable<Allergy>> ListAsync()
        {
            return await _context.Plans.ToListAsync();
        }

        public async Task SaveAsync(Allergy allergy)
        {
            await _context.Plans.AddAsync(allergy);
        }

        public void UpdateAsync(Allergy allergy)
        {
            _context.Update(allergy);
        }
    }
}
