using AutoMapper;
using ReHomeVirtualBackEnd.Membership.Domain.Model;
using ReHomeVirtualBackEnd.Membership.Resources;
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
            CreateMap<Plan, UserResource>();
        }
    }
}
