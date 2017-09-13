using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/backInStockSubscription")]
   public class BackInStockSubscriptionController : ApiController
   {
     IBackInStockSubscriptionDTOService _service;

     public BackInStockSubscriptionController(IBackInStockSubscriptionDTOService service)
     {
        this._service = service;
     }

     // GET: api/BackInStockSubscription
     [Route("")]
     public IEnumerable<BackInStockSubscriptionDTO> Get()
     {
        return _service.GetAllBackInStockSubscription();
     }

     // GET: api/BackInStockSubscription/5
     [Route("{Id:int}")]
     public IHttpActionResult GetBackInStockSubscription(int Id)
     {
        var backInStockSubscription = _service.GetBackInStockSubscription(Id);
        if (backInStockSubscription == null)
        {
          return NotFound();
        }
        return Ok(backInStockSubscription);
     }

     // POST: api/BackInStockSubscription
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertBackInStockSubscription(JsonConvert.DeserializeObject<BackInStockSubscriptionDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/backInStockSubscription", result);
     }

     // PUT: api/BackInStockSubscription/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateBackInStockSubscription(Id, JsonConvert.DeserializeObject<BackInStockSubscriptionDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/BackInStockSubscription/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteBackInStockSubscription(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
