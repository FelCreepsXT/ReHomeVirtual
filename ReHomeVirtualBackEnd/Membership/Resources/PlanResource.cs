using ReHomeVirtualBackEnd.Initialization.Resources;
using ReHomeVirtualBackEnd.Membership.Domain.Model;
using System;

namespace ReHomeVirtualBackEnd.Membership.Resources
{
    public class PlanResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public int MaxSession { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public SubscriptionResource SubscriptionResource { get; set; }
    }
}
