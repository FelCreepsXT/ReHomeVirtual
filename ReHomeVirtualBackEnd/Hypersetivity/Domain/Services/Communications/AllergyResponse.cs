using ReHomeVirtualBackEnd.General.Domain.Services.Communications;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Model;

namespace ReHomeVirtualBackEnd.Hypersetivity.Domain.Services.Response
{
    public class AllergyResponse : BaseResponse<Allergy>
    {
        public AllergyResponse(Allergy resource) : base(resource)
        {
        }

        public AllergyResponse(string message) : base(message)
        {
        }
    }
}
