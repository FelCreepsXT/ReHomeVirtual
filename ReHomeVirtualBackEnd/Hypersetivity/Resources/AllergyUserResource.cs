using ReHomeVirtualBackEnd.Hypersetivity.Domain.Model;
using ReHomeVirtualBackEnd.Initialization.Domain.Model;

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
