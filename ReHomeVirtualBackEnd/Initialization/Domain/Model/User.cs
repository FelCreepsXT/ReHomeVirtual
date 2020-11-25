using ReHomeVirtualBackEnd.Hypersetivity.Domain.Model;
using ReHomeVirtualBackEnd.Meeting.Domain.Model;
using ReHomeVirtualBackEnd.Membership.Domain.Model;
using ReHomeVirtualBackEnd.Social.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Initialization.Domain.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime Brithday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }

        public IList<AllergyUser> AllergyUsers { get; set; } = new List<AllergyUser>();
        public IList<Subscription> Subscriptions { get; set; } = new List<Subscription>();
        public IList<Complaint> Complaints { get; set; } = new List<Complaint>();

        public IList<SessionDatail> SessionDatails { get; set; } = new List<SessionDatail>();
    }
}
