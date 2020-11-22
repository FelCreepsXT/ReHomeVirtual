using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Hypersetivity.Domain.Model
{
    public class Allergy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<AllergyUser> AllergyUsers { get; set; } = new List<AllergyUser>();
    }
}
