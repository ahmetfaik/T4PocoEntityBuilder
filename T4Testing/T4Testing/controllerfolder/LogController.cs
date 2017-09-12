using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/log")]
   public class LogController : ApiController
   {
     ILogDTOService _service;

     public LogController(ILogDTOService service)
     {
        this._service = service;
     }

     // GET: api/Log
     [Route("")]
     public IEnumerable<LogDTO> Get()
     {
        return _service.GetAllLog();
     }

     // GET: api/Log/5
     [Route("{Id:int}")]
     public IHttpActionResult GetLog(int Id)
     {
        var log = _service.GetLog(Id);
        if (log == null)
        {
          return NotFound();
        }
        return Ok(log);
     }

     // POST: api/Log
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertLog(JsonConvert.DeserializeObject<LogDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/log", result);
     }

     // PUT: api/Log/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateLog(Id, JsonConvert.DeserializeObject<LogDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Log/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteLog(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
