using ReHomeVirtualBackEnd.General.General.Persistence.Context;

namespace ReHomeVirtualBackEnd.General.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
