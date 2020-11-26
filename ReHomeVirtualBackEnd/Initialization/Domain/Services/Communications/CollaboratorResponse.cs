using ReHomeVirtualBackEnd.General.Domain.Services.Communications;
using ReHomeVirtualBackEnd.Initialization.Domain.Model;

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
