using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Initialization.Domain.Model
{
    public class Collaborator
    {
        public int Id { get; set; }
        public string Collaboratorname { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Brithday { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public bool Active { get; set; }
    }
}
