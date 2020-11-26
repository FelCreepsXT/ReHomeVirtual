﻿using System.Collections.Generic;

namespace ReHomeVirtualBackEnd.Membership.Domain.Model
{
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public int MaxSession { get; set; }
        public IList<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    }
}
