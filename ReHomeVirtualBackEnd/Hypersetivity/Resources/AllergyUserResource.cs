using ReHomeVirtualBackEnd.Hypersetivity.Domain.Model;
using ReHomeVirtualBackEnd.Initialization.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Hypersetivity.Resources
{
    public class AllergyUserResource
    {
        public int AllergyId { get; set; }
        public virtual Allergy Allergy { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
