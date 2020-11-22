using ReHomeVirtualBackEnd.General.Domain.Repositories;
using ReHomeVirtualBackEnd.General.General.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.General.Repositories
{
    public class UnitOfWork : BaseRepository, IUnitOfWork
    {
        public UnitOfWork(AppDbContext context) : base(context)
        {
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
