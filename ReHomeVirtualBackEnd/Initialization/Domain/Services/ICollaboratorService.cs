using ReHomeVirtualBackEnd.Initialization.Domain.Model;
using ReHomeVirtualBackEnd.Initialization.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Initialization.Domain.Services
{
    public interface ICollaboratorService
    {
        Task<IEnumerable<Collaborator>> ListAsync();

        Task<CollaboratorResponse> GetByIdAsync(int id);

        Task<CollaboratorResponse> SaveAsync(Collaborator collaborator);

        Task<CollaboratorResponse> UpdateAsync(int id, Collaborator collaborator);
        Task<CollaboratorResponse> DeleteAsync(int id);
    }
}
