using System.ComponentModel.DataAnnotations;

namespace ReHomeVirtualBackEnd.Routines.Resources
{
    public class SaveExerciseResource
    {
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
    }
}
