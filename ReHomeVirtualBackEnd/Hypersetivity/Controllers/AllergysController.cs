using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReHomeVirtualBackEnd.General.Extensions;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Model;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Services.Communications;
using ReHomeVirtualBackEnd.Hypersetivity.Resources;
using ReHomeVirtualBackEnd.Initialization.Domain.Model;
using ReHomeVirtualBackEnd.Initialization.Domain.Services.Communications;
using ReHomeVirtualBackEnd.Initialization.Resources;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReHomeVirtualBackEnd.Hypersetivity.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AllergysController : ControllerBase
    {

        private readonly IAllergyService _allergyService;
        private readonly IMapper _mapper;

        public AllergysController(IAllergyService allergyService, IMapper mapper)
        {
            _allergyService = allergyService;
            _mapper = mapper;
        }

        [SwaggerOperation(
          Summary = "List all Allergys",
          Description = "List of Allergys",
          OperationId = "ListAllAllergys",
          Tags = new[] { "Allergys" })]
        [SwaggerResponse(200, "List of Allergys", typeof(IEnumerable<AllergyResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AllergyResource>), 200)]
        public async Task<IEnumerable<AllergyResource>> GetAllAsync()
        {
            var allergies = await _allergyService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Allergy>, IEnumerable<AllergyResource>>(allergies);
            return resources;
        }

        [SwaggerOperation(
               Summary = "Add Allergy",
               Description = "Add new Allergy",
               OperationId = "AddAllergy",
               Tags = new[] { "Allergys" })]
        [SwaggerResponse(200, "Add Allergys", typeof(IEnumerable<AllergyResource>))]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<AllergyResource>), 200)]
        public async Task<IActionResult> PostAsync([FromBody] SaveAllergyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetMessages());
            var allergy = _mapper.Map<SaveAllergyResource, Allergy>(resource);
            var result = await _allergyService.SaveAsync(allergy);

            if (!result.Sucess)
                return BadRequest(result.Message);

            var allergyResource = _mapper.Map<Allergy, AllergyResource>(result.Resource);
            return Ok(allergyResource);
        }


        [SwaggerOperation(
           Summary = "Update Allergy",
           Description = "Update a Allergy",
           OperationId = "UpdateAllergy",
           Tags = new[] { "Allergys" })]
        [SwaggerResponse(200, "Update Allergys", typeof(IEnumerable<AllergyResource>))]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<AllergyResource>), 200)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAllergyResource resource)
        {
            var allergy = _mapper.Map<SaveAllergyResource, Allergy>(resource);
            var result = await _allergyService.UpdateAsync(id, allergy);

            if (!result.Sucess)
                return BadRequest(result.Message);
            var allergyResource = _mapper.Map<Allergy, AllergyResource>(result.Resource);
            return Ok(allergyResource);
        }


        [SwaggerOperation(
        Summary = "Delete Allargy",
        Description = "Delete a Allergy",
        OperationId = "DeleteAllergy",
        Tags = new[] { "Allergys" })]
        [SwaggerResponse(200, "Delete Allergys", typeof(IEnumerable<AllergyResource>))]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<AllergyResource>), 200)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _allergyService.DeleteAsync(id);
            if (!result.Sucess)
                return BadRequest(result.Message);
            var allergyResource = _mapper.Map<Allergy, AllergyResource>(result.Resource);
            return Ok(allergyResource);
        }
    }
}
