﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using Newtonsoft.Json;
using ObjectActor.Interfaces;
using ObjectAPI.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectAPI.Controllers {
   [Route("api/[controller]/{id}")]
   public class ConsumedThingController: Controller {

      [HttpGet("name")]
      public Task<IActionResult> GetNameAsync(string id) {
         throw new NotImplementedException();
      }

      [HttpGet("td")]
      public Task<IActionResult> GetThingDescriptionAsync(string id) {
         throw new NotImplementedException();
      }

      [HttpGet("property/{name}")]
      public async Task<IActionResult> ReadPropertyAsync(string id, string name) {
         var actor = ActorProxy.Create<IObjectActor>(
            new ActorId(id),
            ObjectService.Name.ToServiceUri()
         );

         var potentialError = await actor.ReadPropertyAsync(name);

         // TODO: Send a different action result depending on the presence, and type, of the error.
         return Ok(potentialError);
      }

      [HttpPut("property/{name}")]
      public async Task<IActionResult> WritePropertyAsync(string id, string name, dynamic value) {
         var actor = ActorProxy.Create<IObjectActor>(
            new ActorId(id),
            ObjectService.Name.ToServiceUri()
         );

         var potentialError = await actor.WritePropertyAsync(name, JsonConvert.SerializeObject(value));

         // TODO: Send a different action result depending on the presence, and type, of the error.
         return NoContent();
      }

      [HttpPost("action/{name}")]
      public async Task<IActionResult> InvokeActionAsync(string id, string name, dynamic parameters) {
         var actor = ActorProxy.Create<IObjectActor>(
            new ActorId(id),
            ObjectService.Name.ToServiceUri()
         );

         var potentialError = await actor.InvokeActionAsync(name, JsonConvert.SerializeObject(parameters));

         // TODO: Send a different action result depending on the presence, and type, of the error.
         return Ok(potentialError);
      }

      // Note: Mostly syntactic sugar
      [HttpPost("action")]
      public async Task<IActionResult> InvokeAnonymousActionAsync(string id, AnonymousAction action) {
         var actor = ActorProxy.Create<IObjectActor>(
            new ActorId(id),
            ObjectService.Name.ToServiceUri()
         );

         var potentialError = await actor.InvokeActionAsync(name, JsonConvert.SerializeObject(parameters));

         // TODO: Send a different action result depending on the presence, and type, of the error.
         return Ok(potentialError);
      }

      [HttpPost("on-property-change/{name}")]
      public Task<IActionResult> OnPropertyChangeAsync(string id, string name) {
         throw new NotImplementedException();
      }

      [HttpPost("on-td-change")]
      public Task<IActionResult> OnTDChangeAsync(string id) {
         throw new NotImplementedException();
      }

      [HttpPost("on-event/{name}")]
      public Task<IActionResult> OnEventAsync(string id, string name) {
         throw new NotImplementedException();
      }
   }
}