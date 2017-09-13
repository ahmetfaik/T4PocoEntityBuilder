using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/queuedEmail")]
   public class QueuedEmailController : ApiController
   {
     IQueuedEmailDTOService _service;

     public QueuedEmailController(IQueuedEmailDTOService service)
     {
        this._service = service;
     }

     // GET: api/QueuedEmail
     [Route("")]
     public IEnumerable<QueuedEmailDTO> Get()
     {
        return _service.GetAllQueuedEmail();
     }

     // GET: api/QueuedEmail/5
     [Route("{Id:int}")]
     public IHttpActionResult GetQueuedEmail(int Id)
     {
        var queuedEmail = _service.GetQueuedEmail(Id);
        if (queuedEmail == null)
        {
          return NotFound();
        }
        return Ok(queuedEmail);
     }

     // POST: api/QueuedEmail
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertQueuedEmail(JsonConvert.DeserializeObject<QueuedEmailDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/queuedEmail", result);
     }

     // PUT: api/QueuedEmail/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateQueuedEmail(Id, JsonConvert.DeserializeObject<QueuedEmailDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/QueuedEmail/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteQueuedEmail(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
