using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
