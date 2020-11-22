using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Initialization.Resources
{
    public class SaveUserResource
    {
        [Required]
        [MaxLength(80)]
        public string Username { get; set; }

        [Required]
        [MaxLength(80)]
        public string Password { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Lastname { get; set; }

        [Required]
        public DateTime Brithday { get; set; }

        [Required]
        [MaxLength(10)]
        public string Email { get; set; }

        [Required]
        [MaxLength(12)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(150)]
        public string Address { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}
