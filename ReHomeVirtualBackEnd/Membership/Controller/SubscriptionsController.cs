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
    public class SubscriptionsController : ControllerBase
    {

        private readonly ISubscriptionService _subscriptionService;
        private readonly IMapper _mapper;

        public SubscriptionsController(ISubscriptionService subscriptionService, IMapper mapper)
        {
            _subscriptionService = subscriptionService;
            _mapper = mapper;
        }

        [SwaggerOperation(
          Summary = "List all subscriptions",
          Description = "List of subscription",
          OperationId = "ListAllSubscriptions",
          Tags = new[] { "Subscriptions" })]
        [SwaggerResponse(200, "List of Subscription", typeof(IEnumerable<SubscriptionResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SubscriptionResource>), 200)]
        public async Task<IEnumerable<SubscriptionResource>> GetAllAsync()
        {
            var subscriptions = await _subscriptionService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Subscription>, IEnumerable<SubscriptionResource>>(subscriptions);
            return resources;
        }

        [SwaggerOperation(
               Summary = "Add Subscription",
               Description = "Add new Subscription",
               OperationId = "AddSubscription",
               Tags = new[] { "Subscriptions" })]
        [SwaggerResponse(200, "Add Subscription", typeof(IEnumerable<SubscriptionResource>))]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<SubscriptionResource>), 200)]
        public async Task<IActionResult> PostAsync([FromBody] SaveSubscriptionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetMessages());
            var subscription = _mapper.Map<SaveSubscriptionResource, Subscription>(resource);
            var result = await _subscriptionService.SaveAsync(subscription);

            if (!result.Sucess)
                return BadRequest(result.Message);

            var subscriptionResource = _mapper.Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(subscriptionResource);
        }


        [SwaggerOperation(
           Summary = "Update Subscription",
           Description = "Update a Subscription",
           OperationId = "UpdateSubscriptions",
           Tags = new[] { "Subscriptions" })]
        [SwaggerResponse(200, "Update Subscriptions", typeof(IEnumerable<SubscriptionResource>))]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<SubscriptionResource>), 200)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSubscriptionResource resource)
        {
            var subscription = _mapper.Map<SaveSubscriptionResource, Subscription>(resource);
            var result = await _subscriptionService.UpdateAsync(id, subscription);

            if (!result.Sucess)
                return BadRequest(result.Message);
            var subscriptionResource = _mapper.Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(subscriptionResource);
        }


        [SwaggerOperation(
        Summary = "Delete Subscription",
        Description = "Delete a Subscription",
        OperationId = "DeleteSubscription",
        Tags = new[] { "Subscriptions" })]
        [SwaggerResponse(200, "Delete Subscriptions", typeof(IEnumerable<SubscriptionResource>))]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<SubscriptionResource>), 200)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _subscriptionService.DeleteAsync(id);
            if (!result.Sucess)
                return BadRequest(result.Message);
            var subscriptionResource = _mapper.Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(subscriptionResource);
        }

    }
}
