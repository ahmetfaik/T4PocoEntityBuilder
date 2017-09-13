using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/recurringPayment")]
   public class RecurringPaymentController : ApiController
   {
     IRecurringPaymentDTOService _service;

     public RecurringPaymentController(IRecurringPaymentDTOService service)
     {
        this._service = service;
     }

     // GET: api/RecurringPayment
     [Route("")]
     public IEnumerable<RecurringPaymentDTO> Get()
     {
        return _service.GetAllRecurringPayment();
     }

     // GET: api/RecurringPayment/5
     [Route("{Id:int}")]
     public IHttpActionResult GetRecurringPayment(int Id)
     {
        var recurringPayment = _service.GetRecurringPayment(Id);
        if (recurringPayment == null)
        {
          return NotFound();
        }
        return Ok(recurringPayment);
     }

     // POST: api/RecurringPayment
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertRecurringPayment(JsonConvert.DeserializeObject<RecurringPaymentDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/recurringPayment", result);
     }

     // PUT: api/RecurringPayment/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateRecurringPayment(Id, JsonConvert.DeserializeObject<RecurringPaymentDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/RecurringPayment/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteRecurringPayment(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
