using ReHomeVirtualBackEnd.General.Domain.Services.Communications;
using ReHomeVirtualBackEnd.Membership.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Membership.Domain.Services.Response
{
    public class PlanResponse : BaseResponse<User>
    {
        public PlanResponse(User resource) : base(resource)
        {
        }

        public PlanResponse(string message) : base(message)
        {
        }
    }
}
