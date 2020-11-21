using ReHomeVirtualBackEnd.General.Domain.Services.Communications;
using ReHomeVirtualBackEnd.Routines.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Routines.Domain.Services.Response
{
    public class DietResponse : BaseResponse<Diet>
    {
        public DietResponse(Diet resource) : base(resource)
        {
        }

        public DietResponse(string message) : base(message)
        {
        }
    }
}
