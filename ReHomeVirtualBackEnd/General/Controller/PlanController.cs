using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReHomeVirtualBackEnd.General.Extensions;
using ReHomeVirtualBackEnd.Membership.Domain.Model;
using ReHomeVirtualBackEnd.Membership.Domain.Services.Communications;
using ReHomeVirtualBackEnd.Membership.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace ReHomeVirtualBackEnd.General.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IPlanService _planService;
        private readonly IMapper _mapper;

        public PlanController(IPlanService planService, IMapper mapper)
        {
            _planService = planService;
            _mapper = mapper;
        }

        [SwaggerResponse(200,"List of Plans",typeof(IEnumerable<PlanResource>))]
        [ProducesResponseType(typeof(IEnumerable<PlanResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<PlanResource>> GetAllAsync()
        {
            var plans = await _planService.ListAsync();
            var plansResource = _mapper.Map<IEnumerable<Plan>, IEnumerable<PlanResource>>(plans);
            return plansResource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePlanResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var plan = _mapper.Map<SavePlanResource, Plan>(resource);
            var result = await _planService.SaveAsync(plan);

            if (!result.Sucess)
                return BadRequest(result.Message);

            var planResource = _mapper.Map<Plan, PlanResource>(result.Resource);
            return Ok(planResource);
        }
    }
}
