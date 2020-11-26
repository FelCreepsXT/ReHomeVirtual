using System.Collections.Generic;

namespace ReHomeVirtualBackEnd.Routines.Domain.Model
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<Exercisetag> Exercisetags { get; set; } = new List<Exercisetag>();
    }
}
