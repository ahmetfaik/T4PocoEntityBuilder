using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/externalAuthenticationRecord")]
   public class ExternalAuthenticationRecordController : ApiController
   {
     IExternalAuthenticationRecordDTOService _service;

     public ExternalAuthenticationRecordController(IExternalAuthenticationRecordDTOService service)
     {
        this._service = service;
     }

     // GET: api/ExternalAuthenticationRecord
     [Route("")]
     public IEnumerable<ExternalAuthenticationRecordDTO> Get()
     {
        return _service.GetAllExternalAuthenticationRecord();
     }

     // GET: api/ExternalAuthenticationRecord/5
     [Route("{Id:int}")]
     public IHttpActionResult GetExternalAuthenticationRecord(int Id)
     {
        var externalAuthenticationRecord = _service.GetExternalAuthenticationRecord(Id);
        if (externalAuthenticationRecord == null)
        {
          return NotFound();
        }
        return Ok(externalAuthenticationRecord);
     }

     // POST: api/ExternalAuthenticationRecord
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertExternalAuthenticationRecord(JsonConvert.DeserializeObject<ExternalAuthenticationRecordDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/externalAuthenticationRecord", result);
     }

     // PUT: api/ExternalAuthenticationRecord/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateExternalAuthenticationRecord(Id, JsonConvert.DeserializeObject<ExternalAuthenticationRecordDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/ExternalAuthenticationRecord/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteExternalAuthenticationRecord(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
