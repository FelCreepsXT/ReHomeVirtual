using ReHomeVirtualBackEnd.Meeting.Domain.Model;
using ReHomeVirtualBackEnd.Routines.Domain.Model;
using System;
using System.Collections.Generic;

namespace ReHomeVirtualBackEnd.Initialization.Domain.Model
{
    public class Collaborator
    {
        public int Id { get; set; }
        public string Collaboratorname { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public DateTime Brithday { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public bool Active { get; set; }


        public IList<Diettag> Diettags { get; set; } = new List<Diettag>();

        public IList<Exercisetag> Exercisetags { get; set; } = new List<Exercisetag>();

        public IList<Session> Sessions { get; set; } = new List<Session>();

        public IList<AvailableSchedule> AvailableSchedules { get; set; } = new List<AvailableSchedule>();
    }
}
