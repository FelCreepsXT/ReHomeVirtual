using System.ComponentModel.DataAnnotations;

namespace ReHomeVirtualBackEnd.Membership.Resources
{
    public class SavePlanResource
    {
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public double Cost { get; set; }

        [Required]
        public int MaxSession { get; set; }
    }
}
