using ReHomeVirtualBackEnd.General.Domain.Services.Communications;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
