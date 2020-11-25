using ReHomeVirtualBackEnd.Initialization.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Meeting.Domain.Model
{
    public class AvailableSchedule
    {
        public int id { get; set; }
        public DateTime Starat { get; set; }
        public DateTime Endat { get; set; }

        public bool State { get; set; }

        public int CollaboratorId { get; set; }
        public Collaborator Collaborator { get; set; }
    }
}
