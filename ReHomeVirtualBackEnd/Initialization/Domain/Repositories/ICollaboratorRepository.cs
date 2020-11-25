using ReHomeVirtualBackEnd.Initialization.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Initialization.Domain.Repositories
{
    interface ICollaboratorRepository
    {
        Task<IEnumerable<Collaborator>> ListAsync();
    }
}
