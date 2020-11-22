using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Routines.Resources
{
    public class SaveDietResource
    {
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
    }
}
