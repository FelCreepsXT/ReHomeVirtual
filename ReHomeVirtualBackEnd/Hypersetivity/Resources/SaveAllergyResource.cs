using System.ComponentModel.DataAnnotations;

namespace ReHomeVirtualBackEnd.Hypersetivity.Resources
{
    public class SaveAllergyResource
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
