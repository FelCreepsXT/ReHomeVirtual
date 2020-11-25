using ReHomeVirtualBackEnd.Initialization.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Initialization.Domain.Repositories
{
    public interface ICollaboratorRepository
    {
        Task<IEnumerable<Collaborator>> ListAsync();

        Task AddAsync(Collaborator collaborator);

        Task<Collaborator> FindById(int id);

        void Update(Collaborator collaborator);
        void Remove(Collaborator collaborator);
    }
}
