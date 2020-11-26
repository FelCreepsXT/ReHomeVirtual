using ReHomeVirtualBackEnd.General.Domain.Services.Communications;
using ReHomeVirtualBackEnd.Routines.Domain.Model;

namespace ReHomeVirtualBackEnd.Routines.Domain.Services.Response
{
    public class ExerciseResponse : BaseResponse<Exercise>
    {
        public ExerciseResponse(Exercise resource) : base(resource)
        {
        }

        public ExerciseResponse(string message) : base(message)
        {
        }
    }
}
