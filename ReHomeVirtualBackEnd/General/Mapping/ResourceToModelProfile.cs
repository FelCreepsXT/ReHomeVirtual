using AutoMapper;
using ReHomeVirtualBackEnd.Routines.Domain.Model;
using ReHomeVirtualBackEnd.Routines.Resources;

namespace ReHomeVirtualBackEnd.General.Mapping
{
    public class ResourceToModelProfile:Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveExerciseResource, Exercise>();
            CreateMap<SaveDietResource, Diet>();
        }
    }
}
