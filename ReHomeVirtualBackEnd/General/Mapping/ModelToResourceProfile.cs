using AutoMapper;
using ReHomeVirtualBackEnd.Routines.Domain.Model;
using ReHomeVirtualBackEnd.Routines.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.General.Mapping
{
    public class ModelToResourceProfile:Profile
    {
        public ModelToResourceProfile()
        {
<<<<<<< HEAD:ReHomeVirtualBackEnd/General/Mapping/ModelToResourceProfile.cs
            CreateMap<Exercise, ExerciseResource>();
            CreateMap<Diet, DietResource>();
=======
            CreateMap<Allergy, AllergyResource>();
>>>>>>> app-03-allergy-management:ReHomeVirtualUPC/ReHomeVirtualBackEnd/General/Mapping/ModelToResourceProfile.cs
        }
    }
}
