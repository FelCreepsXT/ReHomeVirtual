using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Membership.Domain.Model
{
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public int MaxSession { get; set; }
    }
}
