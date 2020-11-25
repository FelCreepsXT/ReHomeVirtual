using ReHomeVirtualBackEnd.Initialization.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Social.Domain.Model
{
    public class Raiting
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
        public int CollaboratorId { get; set; }

        public Collaborator Collaborator { get; set; }

        public int ScoreId { get; set; }

        public Score Score { get; set; }

    }
}
