using ReHomeVirtualBackEnd.Initialization.Domain.Model;

namespace ReHomeVirtualBackEnd.Hypersetivity.Domain.Model
{
    public class AllergyUser
    {
        public int AllergyId { get; set; }
        public virtual Allergy Allergy { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
