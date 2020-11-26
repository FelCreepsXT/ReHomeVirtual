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
    [Route("api/diets")]
    [ApiController]
    public class DietController : ControllerBase
    {
        private readonly IDietService _dietService;
        private readonly IMapper _mapper;

        public DietController(IDietService dietService, IMapper mapper)
        {
            _dietService = dietService;
            _mapper = mapper;
        }

        [SwaggerResponse(200, "List of Diets", typeof(IEnumerable<DietResource>))]
        [ProducesResponseType(typeof(IEnumerable<DietResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<DietResource>> GetAllDiets()
        {
            var diets = await _dietService.ListAsync();
            var dietsResource = _mapper.Map<IEnumerable<Diet>, IEnumerable<DietResource>>(diets);
            return dietsResource;
        }

        [HttpPost]
        public async Task<IActionResult> PostDiet([FromBody] SaveDietResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetMessages());

            var diet = _mapper.Map<SaveDietResource, Diet>(resource);
            var result = await _dietService.SaveAsync(diet);

            if (!result.Sucess)
                return BadRequest(result.Message);

            var dietResource = _mapper.Map<Diet, DietResource>(result.Resource);
            return Ok(dietResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiet(int id, [FromBody] SaveDietResource resource)
        {
            var diet = _mapper.Map<SaveDietResource, Diet>(resource);
            var result = await _dietService.UpdateAsync(id, diet);

            if (!result.Sucess)
                return BadRequest(result.Message);

            var dietResource = _mapper.Map<Diet, DietResource>(result.Resource);
            return Ok(dietResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiet(int id)
        {
            var result = await _dietService.DeleteAsync(id);

            if (!result.Sucess)
                return BadRequest(result.Message);

            var dietResource = _mapper.Map<Diet, DietResource>(result.Resource);
            return Ok(dietResource);
        }
    }
}
