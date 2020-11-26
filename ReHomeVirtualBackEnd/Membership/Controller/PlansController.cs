using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReHomeVirtualBackEnd.General.Extensions;
using ReHomeVirtualBackEnd.Membership.Domain.Model;
using ReHomeVirtualBackEnd.Membership.Domain.Services;
using ReHomeVirtualBackEnd.Membership.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace ReHomeVirtualBackEnd.Membership.Controller
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PlansController : ControllerBase
    {

        private readonly IPlanService _planService;
        private readonly IMapper _mapper;

        public PlansController(IPlanService planService, IMapper mapper)
        {
            _planService = planService;
            _mapper = mapper;
        }

        [SwaggerOperation(
          Summary = "List all plans",
          Description = "List of Plans",
          OperationId = "ListAllPlans",
          Tags = new[] { "Plans" })]
        [SwaggerResponse(200, "List of Plan", typeof(IEnumerable<PlanResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PlanResource>), 200)]
        public async Task<IEnumerable<PlanResource>> GetAllAsync()
        {
            var plans = await _planService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Plan>, IEnumerable<PlanResource>>(plans);
            return resources;
        }

        [SwaggerOperation(
               Summary = "Add Plans",
               Description = "Add new plan",
               OperationId = "AddPlan",
               Tags = new[] { "Plans" })]
        [SwaggerResponse(200, "Add Plans", typeof(IEnumerable<PlanResource>))]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<PlanResource>), 200)]
        public async Task<IActionResult> PostAsync([FromBody] SavePlanResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetMessages());
            var plan = _mapper.Map<SavePlanResource, Plan>(resource);
            var result = await _planService.SaveAsync(plan);

            if (!result.Sucess)
                return BadRequest(result.Message);

            var planResource = _mapper.Map<Plan, PlanResource>(result.Resource);
            return Ok(planResource);
        }


        [SwaggerOperation(
           Summary = "Update plan",
           Description = "Update a plan",
           OperationId = "UpdatePlans",
           Tags = new[] { "Plans" })]
        [SwaggerResponse(200, "Update Plans", typeof(IEnumerable<PlanResource>))]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<PlanResource>), 200)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePlanResource resource)
        {
            var plan = _mapper.Map<SavePlanResource, Plan>(resource);
            var result = await _planService.UpdateAsync(id, plan);

            if (!result.Sucess)
                return BadRequest(result.Message);
            var planResource = _mapper.Map<Plan, PlanResource>(result.Resource);
            return Ok(planResource);
        }


        [SwaggerOperation(
        Summary = "Delete plan",
        Description = "Delete a plan",
        OperationId = "DeletePlan",
        Tags = new[] { "Plans" })]
        [SwaggerResponse(200, "Delete Plans", typeof(IEnumerable<PlanResource>))]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<PlanResource>), 200)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _planService.DeleteAsync(id);
            if (!result.Sucess)
                return BadRequest(result.Message);
            var planResource = _mapper.Map<Plan, PlanResource>(result.Resource);
            return Ok(planResource);
        }

    }
}
