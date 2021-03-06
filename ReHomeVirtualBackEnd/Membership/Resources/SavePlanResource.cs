﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
