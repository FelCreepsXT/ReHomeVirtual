using System.ComponentModel.DataAnnotations;

namespace ReHomeVirtualBackEnd.Hypersetivity.Resources
{
    public class SaveAllergyUserResource
    {
        [Required]
        public int AllergyId { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
