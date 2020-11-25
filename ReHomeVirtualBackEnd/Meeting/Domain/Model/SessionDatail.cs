using ReHomeVirtualBackEnd.Initialization.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Meeting.Domain.Model
{
    public class SessionDatail
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public string Room { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int SessionId { get; set; }

        public Session Session { get; set; }
    }
}
