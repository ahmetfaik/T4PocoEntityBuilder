using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/forums_Subscription")]
   public class Forums_SubscriptionController : ApiController
   {
     IForums_SubscriptionDTOService _service;

     public Forums_SubscriptionController(IForums_SubscriptionDTOService service)
     {
        this._service = service;
     }

     // GET: api/Forums_Subscription
     [Route("")]
     public IEnumerable<Forums_SubscriptionDTO> Get()
     {
        return _service.GetAllForums_Subscription();
     }

     // GET: api/Forums_Subscription/5
     [Route("{Id:int}")]
     public IHttpActionResult GetForums_Subscription(int Id)
     {
        var forums_Subscription = _service.GetForums_Subscription(Id);
        if (forums_Subscription == null)
        {
          return NotFound();
        }
        return Ok(forums_Subscription);
     }

     // POST: api/Forums_Subscription
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertForums_Subscription(JsonConvert.DeserializeObject<Forums_SubscriptionDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/forums_Subscription", result);
     }

     // PUT: api/Forums_Subscription/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateForums_Subscription(Id, JsonConvert.DeserializeObject<Forums_SubscriptionDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Forums_Subscription/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteForums_Subscription(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
