using ReHomeVirtualBackEnd.Initialization.Domain.Model;

namespace ReHomeVirtualBackEnd.Routines.Domain.Model
{
    public class Exercisetag
    {
        public int Id { get; set; }

        public int ExerciseId { get; set; }

        public Exercise Exercise { get; set; }

        public int TagId { get; set; }

        public Tag Tag { get; set; }

        public int CollaboratorId { get; set; }

        public Collaborator Collaborator { get; set; }
    }
}
