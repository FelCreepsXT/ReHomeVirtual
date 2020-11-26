using System.Collections.Generic;

namespace ReHomeVirtualBackEnd.Routines.Domain.Model
{
    public class Tag
    {
        public int Id { get; set; }

        public string Nametag { get; set; }

        public bool Isdiet { get; set; }

        public IList<Diettag> Diettags { get; set; } = new List<Diettag>();
        public IList<Exercisetag> Exercisetags { get; set; } = new List<Exercisetag>();
    }
}
