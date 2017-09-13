using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/recurringPaymentHistory")]
   public class RecurringPaymentHistoryController : ApiController
   {
     IRecurringPaymentHistoryDTOService _service;

     public RecurringPaymentHistoryController(IRecurringPaymentHistoryDTOService service)
     {
        this._service = service;
     }

     // GET: api/RecurringPaymentHistory
     [Route("")]
     public IEnumerable<RecurringPaymentHistoryDTO> Get()
     {
        return _service.GetAllRecurringPaymentHistory();
     }

     // GET: api/RecurringPaymentHistory/5
     [Route("{Id:int}")]
     public IHttpActionResult GetRecurringPaymentHistory(int Id)
     {
        var recurringPaymentHistory = _service.GetRecurringPaymentHistory(Id);
        if (recurringPaymentHistory == null)
        {
          return NotFound();
        }
        return Ok(recurringPaymentHistory);
     }

     // POST: api/RecurringPaymentHistory
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertRecurringPaymentHistory(JsonConvert.DeserializeObject<RecurringPaymentHistoryDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/recurringPaymentHistory", result);
     }

     // PUT: api/RecurringPaymentHistory/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateRecurringPaymentHistory(Id, JsonConvert.DeserializeObject<RecurringPaymentHistoryDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/RecurringPaymentHistory/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteRecurringPaymentHistory(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
