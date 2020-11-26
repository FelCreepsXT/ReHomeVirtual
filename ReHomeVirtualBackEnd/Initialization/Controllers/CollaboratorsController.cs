using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReHomeVirtualBackEnd.General.Extensions;
using ReHomeVirtualBackEnd.Initialization.Domain.Model;
using ReHomeVirtualBackEnd.Initialization.Domain.Services;
using ReHomeVirtualBackEnd.Initialization.Resources;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ReHomeVirtualBackEnd.Initialization.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]

    public class CollaboratorsController : ControllerBase
    {
        private readonly ICollaboratorService _collaboratorService;
        private readonly IMapper _mapper;

        public CollaboratorsController(ICollaboratorService collaboratorService, IMapper mapper)
        {
            _collaboratorService = collaboratorService;
            _mapper = mapper;
        }


        [SwaggerOperation(
         Summary = "List all Collaborators",
         Description = "List of Collaborators",
         OperationId = "ListAllCollaborators",
         Tags = new[] { "Collaborators" })]
        [SwaggerResponse(200, "List of Collaborators", typeof(IEnumerable<CollaboratorResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CollaboratorResource>), 200)]
        public async Task<IEnumerable<CollaboratorResource>> GetAllAsync()
        {
            var collaborators = await _collaboratorService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Collaborator>, IEnumerable<CollaboratorResource>>(collaborators);
            return resources;
        }


        [SwaggerOperation(
                      Summary = "Add collaborators",
                      Description = "Add new collaborators",
                      OperationId = "AddCollaborators",
                      Tags = new[] { "Collaborators" })]
        [SwaggerResponse(200, "Add Collaborators", typeof(IEnumerable<CollaboratorResource>))]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<CollaboratorResource>), 200)]

        public async Task<IActionResult> PostAsync([FromBody] SaveCollaboratorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetMessages());
            var collaborator = _mapper.Map<SaveCollaboratorResource, Collaborator>(resource);
            var result = await _collaboratorService.SaveAsync(collaborator);

            if (!result.Sucess)
                return BadRequest(result.Message);

            var collaboratorResource = _mapper.Map<Collaborator, CollaboratorResource>(result.Resource);
            return Ok(collaboratorResource);
        }

        [SwaggerOperation(
            Summary = "Update Collaborator",
            Description = "Update a Collaborator",
            OperationId = "UpdateCollaborator",
            Tags = new[] { "Collaborators" })]
        [SwaggerResponse(200, "Update Collaborators", typeof(IEnumerable<CollaboratorResource>))]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<CollaboratorResource>), 200)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCollaboratorResource resource)
        {
            var collaborator = _mapper.Map<SaveCollaboratorResource, Collaborator>(resource);
            var result = await _collaboratorService.UpdateAsync(id, collaborator);

            if (!result.Sucess)
                return BadRequest(result.Message);
            var collaboratorResource = _mapper.Map<Collaborator, CollaboratorResource>(result.Resource);
            return Ok(collaboratorResource);
        }

        [SwaggerOperation(
      Summary = "Delete Collaborator",
      Description = "Delete a Collaborator",
      OperationId = "DeleteCollaborator",
      Tags = new[] { "Collaborators" })]
        [SwaggerResponse(200, "Delete Collaborators", typeof(IEnumerable<CollaboratorResource>))]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<CollaboratorResource>), 200)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _collaboratorService.DeleteAsync(id);
            if (!result.Sucess)
                return BadRequest(result.Message);
            var collaboratorResource = _mapper.Map<Collaborator, CollaboratorResource>(result.Resource);
            return Ok(collaboratorResource);
        }

    }
}
