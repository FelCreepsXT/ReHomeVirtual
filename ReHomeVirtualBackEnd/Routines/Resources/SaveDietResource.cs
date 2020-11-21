using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Routines.Resources
{
<<<<<<< HEAD:ReHomeVirtualBackEnd/Initialization/Resources/SaveUserResource.cs
    public class SaveUserResource
=======
    public class SaveDietResource
>>>>>>> app-08-exercise-management:ReHomeVirtualBackEnd/Routines/Resources/SaveDietResource.cs
    {
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
    }
}
