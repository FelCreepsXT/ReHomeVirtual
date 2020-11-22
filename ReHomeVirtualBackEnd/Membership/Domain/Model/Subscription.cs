using ReHomeVirtualBackEnd.Initialization.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Membership.Domain.Model
{
    public class Subscription
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PlanId { get; set; }
        public Plan Plan { get; set; }
    }
}
