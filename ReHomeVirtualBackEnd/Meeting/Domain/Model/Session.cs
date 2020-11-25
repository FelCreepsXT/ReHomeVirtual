using ReHomeVirtualBackEnd.Initialization.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Meeting.Domain.Model
{
    public class Session
    {
        public int Id { get; set; }

        public DateTime Starat { get; set; }

        public DateTime Endat { get; set; }

        public int CollaboratorId { get; set; }

        public Collaborator Collaborator { get; set; }

        public IList<SessionDatail> SessionDatails { get; set; } = new List<SessionDatail>();
    }
}
