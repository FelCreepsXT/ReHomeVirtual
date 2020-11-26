using Microsoft.EntityFrameworkCore;
using ReHomeVirtualBackEnd.General.General.Persistence.Context;
using ReHomeVirtualBackEnd.General.Repositories;
using ReHomeVirtualBackEnd.Initialization.Domain.Model;
using ReHomeVirtualBackEnd.Initialization.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ReHomeVirtualBackEnd.Initialization.Persistence.Repositories
{
    public class CollaboratorRepository : BaseRepository, ICollaboratorRepository
    {
        public CollaboratorRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Collaborator collaborator)
        {
            await _context.Collaborators.AddAsync(collaborator);
        }

        public async Task<Collaborator> FindById(int id)
        {
            return await _context.Collaborators.FindAsync(id);
        }

        public async Task<IEnumerable<Collaborator>> ListAsync()
        {
            return await _context.Collaborators.ToListAsync();
        }

        public void Remove(Collaborator collaborator)
        {
            _context.Collaborators.Remove(collaborator);
        }

        public void Update(Collaborator collaborator)
        {
            _context.Collaborators.Update(collaborator);
        }
    }
}
