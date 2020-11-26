using System.Collections.Generic;

namespace ReHomeVirtualBackEnd.Routines.Domain.Model
{
    public class Diet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<Diettag> Diettags { get; set; } = new List<Diettag>();
    }
}
