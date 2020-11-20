using AutoMapper;
using ReHomeVirtualBackEnd.Membership.Domain.Model;
using ReHomeVirtualBackEnd.Membership.Resources;

namespace ReHomeVirtualBackEnd.General.Extensions
{
    public class ResourceToModelProfile:Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserResource, Plan>();
        }
    }
}
