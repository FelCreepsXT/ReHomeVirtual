using AutoMapper;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Model;
using ReHomeVirtualBackEnd.Hypersetivity.Resources;
using ReHomeVirtualBackEnd.Initialization.Domain.Model;
using ReHomeVirtualBackEnd.Initialization.Resources;
using ReHomeVirtualBackEnd.Membership.Domain.Model;
using ReHomeVirtualBackEnd.Membership.Resources;
using ReHomeVirtualBackEnd.Routines.Domain.Model;
using ReHomeVirtualBackEnd.Routines.Resources;

namespace ReHomeVirtualBackEnd.General.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Plan, PlanResource>();
            CreateMap<Diet, DietResource>();
            CreateMap<Exercise, ExerciseResource>();
            CreateMap<User, UserResource>();
            CreateMap<Allergy, AllergyResource>();
        }
    }
}
