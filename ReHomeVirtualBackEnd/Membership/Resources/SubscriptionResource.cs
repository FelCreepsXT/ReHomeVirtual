using ReHomeVirtualBackEnd.Initialization.Domain.Model;
using ReHomeVirtualBackEnd.Initialization.Resources;
using ReHomeVirtualBackEnd.Membership.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Membership.Resources
{
    public class SubscriptionResource
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public int MaxSessions { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public UserResource User { get; set; }
     
    }
}
