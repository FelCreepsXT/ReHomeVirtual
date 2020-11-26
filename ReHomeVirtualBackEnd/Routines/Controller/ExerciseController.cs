using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReHomeVirtualBackEnd.General.Extensions;
using ReHomeVirtualBackEnd.Routines.Domain.Model;
using ReHomeVirtualBackEnd.Routines.Domain.Services;
using ReHomeVirtualBackEnd.Routines.Resources;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Routines.Controller
{
    [Route("api/exercises")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;
        private readonly IMapper _mapper;

        public ExerciseController(IExerciseService exerciseService, IMapper mapper)
        {
            _exerciseService = exerciseService;
            _mapper = mapper;
        }

        [SwaggerResponse(200, "List of Exercise", typeof(IEnumerable<ExerciseResource>))]
        [ProducesResponseType(typeof(IEnumerable<ExerciseResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<ExerciseResource>> GetAllExercise()
        {
            var exercises = await _exerciseService.ListAsync();
            var exercisesResource = _mapper.Map<IEnumerable<Exercise>, IEnumerable<ExerciseResource>>(exercises);
            return exercisesResource;
        }

        [HttpPost]
        public async Task<IActionResult> PostExercise([FromBody] SaveExerciseResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetMessages());

            var exercise = _mapper.Map<SaveExerciseResource, Exercise>(resource);
            var result = await _exerciseService.SaveAsync(exercise);

            if (!result.Sucess)
                return BadRequest(result.Message);

            var exerciseResource = _mapper.Map<Exercise, ExerciseResource>(result.Resource);
            return Ok(exerciseResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutExercise(int id, [FromBody] SaveExerciseResource resource)
        {
            var exercise = _mapper.Map<SaveExerciseResource, Exercise>(resource);
            var result = await _exerciseService.UpdateAsync(id, exercise);

            if (!result.Sucess)
                return BadRequest(result.Message);

            var exerciseResource = _mapper.Map<Exercise, ExerciseResource>(result.Resource);
            return Ok(exerciseResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            var result = await _exerciseService.DeleteAsync(id);

            if (!result.Sucess)
                return BadRequest(result.Message);

            var exerciseResource = _mapper.Map<Exercise, ExerciseResource>(result.Resource);
            return Ok(exerciseResource);
        }
    }
}
