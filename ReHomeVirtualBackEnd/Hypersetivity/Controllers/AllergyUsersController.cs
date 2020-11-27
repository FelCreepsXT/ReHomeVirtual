using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReHomeVirtualBackEnd.General.Extensions;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Model;
using ReHomeVirtualBackEnd.Hypersetivity.Domain.Services;
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
    public class AllergyUsersController : ControllerBase
    {

        private readonly IAllergyUserService _allergyuserService;
        private readonly IMapper _mapper;

        public AllergyUsersController(IAllergyUserService allergyuserService, IMapper mapper)
        {
            _allergyuserService = allergyuserService;
            _mapper = mapper;
        }

        [SwaggerOperation(
          Summary = "List all AllergyUsers",
          Description = "List of AllergyUsers",
          OperationId = "ListAllAllergyUsers",
          Tags = new[] { "AllergyUsers" })]
        [SwaggerResponse(200, "List of AllergyUsers", typeof(IEnumerable<AllergyUserResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AllergyUserResource>), 200)]
        public async Task<IEnumerable<AllergyUserResource>> GetAllAsync()
        {
            var allergyusers = await _allergyuserService.ListAsync();
            var resources = _mapper.Map<IEnumerable<AllergyUser>, IEnumerable<AllergyUserResource>>(allergyusers);
            return resources;
        }

        [SwaggerOperation(
               Summary = "Add AllergyUsers",
               Description = "Add new AllergyUsers",
               OperationId = "AddAllergyUsers",
               Tags = new[] { "AllergyUsers" })]
        [SwaggerResponse(200, "Add AllergyUsers", typeof(IEnumerable<AllergyUserResource>))]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<AllergyUserResource>), 200)]
        public async Task<IActionResult> PostAsync([FromBody] SaveAllergyUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetMessages());
            var allergyuser = _mapper.Map<SaveAllergyUserResource, AllergyUser>(resource);
            var result = await _allergyuserService.SaveAsync(allergyuser);

            if (!result.Sucess)
                return BadRequest(result.Message);

            var allergyuserResource = _mapper.Map<AllergyUser, AllergyUserResource>(result.Resource);
            return Ok(allergyuserResource);
        }


        [SwaggerOperation(
           Summary = "Update AllergyUsers",
           Description = "Update a AllergyUsers",
           OperationId = "UpdateAllergyUsers",
           Tags = new[] { "AllergyUsers" })]
        [SwaggerResponse(200, "Update AllergyUsers", typeof(IEnumerable<AllergyUserResource>))]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<AllergyUserResource>), 200)]
        public async Task<IActionResult> PutAsync(int id, int allergy, [FromBody] SaveAllergyUserResource resource)
        {
            var allergyuser = _mapper.Map<SaveAllergyUserResource, AllergyUser>(resource);

            var result = await _allergyuserService.UpdateAsync(id , allergy , allergyuser);

            if (!result.Sucess)
                return BadRequest(result.Message);
            var allergyuserResource = _mapper.Map<AllergyUser, AllergyUserResource>(result.Resource);
            return Ok(allergyuserResource);
        }


        [SwaggerOperation(
        Summary = "Delete AllargyUsers",
        Description = "Delete a AllergyUsers",
        OperationId = "DeleteAllergyUsers",
        Tags = new[] { "AllergyUsers" })]
        [SwaggerResponse(200, "Delete AllergyUsers", typeof(IEnumerable<AllergyUserResource>))]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<AllergyUserResource>), 200)]
        public async Task<IActionResult> RemoveAsync(int id, int allergyid)
        {
            var result = await _allergyuserService.RemoveAsync(id, allergyid);
            if (!result.Sucess)
                return BadRequest(result.Message);
            var allergyuserResource = _mapper.Map<AllergyUser, AllergyUserResource>(result.Resource);
            return Ok(allergyuserResource);
        }
    }
}
