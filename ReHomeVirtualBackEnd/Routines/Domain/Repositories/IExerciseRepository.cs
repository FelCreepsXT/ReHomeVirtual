using ReHomeVirtualBackEnd.Routines.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Routines.Domain.Repositories
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<Exercise>> ListAsync();
        Task<Exercise> FindById(int id);
        Task SaveAsync(Exercise exercise);
        void DeleteAsync(Exercise exercise);
        void UpdateAsync(Exercise exercise);
    }
}
