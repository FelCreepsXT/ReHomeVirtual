using AutoMapper;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Model;
using ReHomeVirtualBackEnd.Hypersetivity.Resources;
using ReHomeVirtualBackEnd.Initialization.Domain.Model;
using ReHomeVirtualBackEnd.Initialization.Resources;
using ReHomeVirtualBackEnd.Membership.Domain.Model;
using ReHomeVirtualBackEnd.Membership.Resources;
using ReHomeVirtualBackEnd.Routines.Domain.Model;
using ReHomeVirtualBackEnd.Routines.Resources;

namespace ReHomeVirtualBackEnd.General.Extensions
{
    public class ResourceToModelProfile:Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePlanResource, Plan>();
            CreateMap<SaveExerciseResource, Exercise>();
            CreateMap<SaveDietResource, Diet>();
            CreateMap<SaveAllergyResource, Allergy>();
            CreateMap<SaveUserResource, User>();
        }
    }
}
