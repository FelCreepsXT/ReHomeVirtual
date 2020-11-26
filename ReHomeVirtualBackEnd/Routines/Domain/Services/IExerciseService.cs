using ReHomeVirtualBackEnd.Routines.Domain.Model;
using ReHomeVirtualBackEnd.Routines.Domain.Services.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Routines.Domain.Services
{
    public interface IExerciseService
    {
        Task<IEnumerable<Exercise>> ListAsync();
        Task<ExerciseResponse> SaveAsync(Exercise exercise);
        Task<ExerciseResponse> DeleteAsync(int id);
        Task<ExerciseResponse> UpdateAsync(int id, Exercise exercise);
    }
}
