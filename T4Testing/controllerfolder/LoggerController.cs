using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/logger")]
   public class LoggerController : ApiController
   {
     ILoggerDTOService _service;

     public LoggerController(ILoggerDTOService service)
     {
        this._service = service;
     }

     // GET: api/Logger
     [Route("")]
     public IEnumerable<LoggerDTO> Get()
     {
        return _service.GetAllLogger();
     }

     // GET: api/Logger/5
     [Route("{Id:int}")]
     public IHttpActionResult GetLogger(int Id)
     {
        var logger = _service.GetLogger(Id);
        if (logger == null)
        {
          return NotFound();
        }
        return Ok(logger);
     }

     // POST: api/Logger
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertLogger(JsonConvert.DeserializeObject<LoggerDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/logger", result);
     }

     // PUT: api/Logger/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateLogger(Id, JsonConvert.DeserializeObject<LoggerDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Logger/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteLogger(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
