using Microsoft.EntityFrameworkCore;
using ReHomeVirtualBackEnd.General.General.Persistence.Context;
using ReHomeVirtualBackEnd.General.Repositories;
using ReHomeVirtualBackEnd.Membership.Domain.Model;
using ReHomeVirtualBackEnd.Membership.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Membership.Persistence.Repositories
{
    public class PlanRepository : BaseRepository, IPlanRepository
    {
        public PlanRepository(AppDbContext context) : base(context)
        {
        }

        public void DeleteAsync(User plan)
        {
            _context.Plans.Remove(plan);
        }

        public async Task<User> FindById(int id)
        {
            return await _context.FindAsync(id);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Plans.ToListAsync();
        }

        public async Task SaveAsync(User plan)
        {
            await _context.Plans.AddAsync(plan);
        }

        public void UpdateAsync(User plan)
        {
            _context.Update(plan);
        }
    }
}
