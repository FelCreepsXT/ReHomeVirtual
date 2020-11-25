using ReHomeVirtualBackEnd.General.Domain.Services.Communications;
using ReHomeVirtualBackEnd.Initialization.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Initialization.Domain.Services.Communications
{
    public class CollaboratorResponse : BaseResponse<Collaborator>
    {
        public CollaboratorResponse(Collaborator resource) : base(resource)
        {
        }

        public CollaboratorResponse(string message) : base(message)
        {
        }
    }
}
