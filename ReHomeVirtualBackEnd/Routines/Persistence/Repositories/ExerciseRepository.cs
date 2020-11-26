using Microsoft.EntityFrameworkCore;
using ReHomeVirtualBackEnd.General.General.Persistence.Context;
using ReHomeVirtualBackEnd.General.Repositories;
using ReHomeVirtualBackEnd.Routines.Domain.Model;
using ReHomeVirtualBackEnd.Routines.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Routines.Persistence.Repositories
{
    public class ExerciseRepository : BaseRepository, IExerciseRepository
    {
        public ExerciseRepository(AppDbContext context) : base(context)
        {
        }

        public void DeleteAsync(Exercise exercise)
        {
            _context.Exercises.Remove(exercise);
        }

        public async Task<Exercise> FindById(int id)
        {
            return await _context.Exercises.FindAsync(id);
        }

        public async Task<IEnumerable<Exercise>> ListAsync()
        {
            return await _context.Exercises.ToListAsync();
        }

        public async Task SaveAsync(Exercise exercise)
        {
            await _context.Exercises.AddAsync(exercise);
        }

        public void UpdateAsync(Exercise exercise)
        {
            _context.Exercises.Update(exercise);
        }
    }
}
