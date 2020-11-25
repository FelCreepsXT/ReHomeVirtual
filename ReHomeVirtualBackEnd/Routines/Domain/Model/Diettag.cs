using ReHomeVirtualBackEnd.Initialization.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Routines.Domain.Model
{
    public class Diettag
    {
        public int Id { get; set; }
        public int DietId { get; set; }

        public Diet Diet { get; set; }
        public int TagId { get; set; }

        public Tag Tag { get; set; }

        public int CollaboratorId { get; set; }

        public Collaborator Collaborator { get; set; }
    }
}
