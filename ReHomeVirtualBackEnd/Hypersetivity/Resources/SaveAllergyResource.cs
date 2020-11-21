using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

<<<<<<< HEAD:ReHomeVirtualBackEnd/Routines/Resources/SaveDietResource.cs
namespace ReHomeVirtualBackEnd.Routines.Resources
{
    public class SaveDietResource
=======
namespace ReHomeVirtualBackEnd.Hypersetivity.Resources
{
    public class SaveAllergyResource
>>>>>>> app-03-allergy-management:ReHomeVirtualBackEnd/Hypersetivity/Resources/SaveAllergyResource.cs
    {
        [MaxLength(30)]
        public string Name { get; set; }
<<<<<<< HEAD:ReHomeVirtualBackEnd/Routines/Resources/SaveDietResource.cs

        [MaxLength(250)]
        public string Description { get; set; }
=======
>>>>>>> app-03-allergy-management:ReHomeVirtualBackEnd/Hypersetivity/Resources/SaveAllergyResource.cs
    }
}
