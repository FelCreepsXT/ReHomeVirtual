using System.ComponentModel.DataAnnotations;

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
