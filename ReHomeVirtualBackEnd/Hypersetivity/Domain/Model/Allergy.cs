using System.Collections.Generic;

namespace ReHomeVirtualBackEnd.Hypersetivity.Domain.Model
{
    public class Allergy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<AllergyUser> AllergyUsers { get; set; } = new List<AllergyUser>();
    }
}
