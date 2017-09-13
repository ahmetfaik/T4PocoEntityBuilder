using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/activityLog")]
   public class ActivityLogController : ApiController
   {
     IActivityLogDTOService _service;

     public ActivityLogController(IActivityLogDTOService service)
     {
        this._service = service;
     }

     // GET: api/ActivityLog
     [Route("")]
     public IEnumerable<ActivityLogDTO> Get()
     {
        return _service.GetAllActivityLog();
     }

     // GET: api/ActivityLog/5
     [Route("{Id:int}")]
     public IHttpActionResult GetActivityLog(int Id)
     {
        var activityLog = _service.GetActivityLog(Id);
        if (activityLog == null)
        {
          return NotFound();
        }
        return Ok(activityLog);
     }

     // POST: api/ActivityLog
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertActivityLog(JsonConvert.DeserializeObject<ActivityLogDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/activityLog", result);
     }

     // PUT: api/ActivityLog/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateActivityLog(Id, JsonConvert.DeserializeObject<ActivityLogDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/ActivityLog/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteActivityLog(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
