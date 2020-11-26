using ReHomeVirtualBackEnd.General.Domain.Services.Communications;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Model;

namespace ReHomeVirtualBackEnd.Hypersetivity.Domain.Services.Communications
{
    public class AllergyUserResponse : BaseResponse<AllergyUser>
    {
        public AllergyUserResponse(AllergyUser resource) : base(resource)
        {
        }

        public AllergyUserResponse(string message) : base(message)
        {
        }
    }
}
