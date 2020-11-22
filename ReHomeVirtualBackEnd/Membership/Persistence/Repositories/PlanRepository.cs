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

        public void DeleteAsync(Plan plan)
        {
            _context.Plans.Remove(plan);
        }

        public async Task<Plan> FindById(int id)
        {
            return await _context.Plans.FindAsync(id);
        }

        public async Task<IEnumerable<Plan>> ListAsync()
        {
            return await _context.Plans.ToListAsync();
        }

        public async Task SaveAsync(Plan plan)
        {
            await _context.Plans.AddAsync(plan);
        }

        public void UpdateAsync(Plan plan)
        {
            _context.Update(plan);
        }
    }
}
