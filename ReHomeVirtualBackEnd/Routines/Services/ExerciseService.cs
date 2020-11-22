using ReHomeVirtualBackEnd.General.Domain.Repositories;
using ReHomeVirtualBackEnd.Routines.Domain.Model;
using ReHomeVirtualBackEnd.Routines.Domain.Repositories;
using ReHomeVirtualBackEnd.Routines.Domain.Services;
using ReHomeVirtualBackEnd.Routines.Domain.Services.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Routines.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ExerciseService(IExerciseRepository exerciseRepository, IUnitOfWork unitOfWork)
        {
            _exerciseRepository = exerciseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ExerciseResponse> DeleteAsync(int id)
        {
            var existingexercise = await _exerciseRepository.FindById(id);
            if (existingexercise == null)
                return new ExerciseResponse("exercise not found");

            try
            {
                _exerciseRepository.DeleteAsync(existingexercise);
                await _unitOfWork.CompleteAsync();
                return new ExerciseResponse(existingexercise);
            }
            catch (Exception e)
            {
                return new ExerciseResponse($"An error ocurred while deleting exercise: {e.Message}");
            }
        }

        public async Task<IEnumerable<Exercise>> ListAsync()
        {
            return await _exerciseRepository.ListAsync();
        }

        public async Task<ExerciseResponse> SaveAsync(Exercise exercise)
        {
            try
            {
                await _exerciseRepository.SaveAsync(exercise);
                await _unitOfWork.CompleteAsync();
                return new ExerciseResponse(exercise);
            }
            catch (Exception e)
            {
                return new ExerciseResponse($"An error ocurred while saving exercise: {e.Message}");
            }
        }

        public async Task<ExerciseResponse> UpdateAsync(int id, Exercise exercise)
        {
            var existingexercise = await _exerciseRepository.FindById(id);
            if (existingexercise == null)
                return new ExerciseResponse("exercise not found");

            try
            {
                _exerciseRepository.UpdateAsync(existingexercise);
                await _unitOfWork.CompleteAsync();
                return new ExerciseResponse(existingexercise);
            }
            catch (Exception e)
            {
                return new ExerciseResponse($"An error ocurred while updating exercise: {e.Message}");
            }
        }
    }
}
