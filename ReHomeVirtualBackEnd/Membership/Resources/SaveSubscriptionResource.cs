using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Membership.Resources
{
    public class SaveSubscriptionResource
    {
        [Required]
        public bool Active { get; set; }

        [MaxLength(40)]
        [Required]
        public int MaxSessions { get; set; }

        [Required]
        public DateTime CreateAt { get; set; }

        [Required]
        public DateTime UpdateAt { get; set; }

        public int UserId { get; set; }
    }
}

