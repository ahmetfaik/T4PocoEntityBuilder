using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/activityLogType")]
   public class ActivityLogTypeController : ApiController
   {
     IActivityLogTypeDTOService _service;

     public ActivityLogTypeController(IActivityLogTypeDTOService service)
     {
        this._service = service;
     }

     // GET: api/ActivityLogType
     [Route("")]
     public IEnumerable<ActivityLogTypeDTO> Get()
     {
        return _service.GetAllActivityLogType();
     }

     // GET: api/ActivityLogType/5
     [Route("{Id:int}")]
     public IHttpActionResult GetActivityLogType(int Id)
     {
        var activityLogType = _service.GetActivityLogType(Id);
        if (activityLogType == null)
        {
          return NotFound();
        }
        return Ok(activityLogType);
     }

     // POST: api/ActivityLogType
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertActivityLogType(JsonConvert.DeserializeObject<ActivityLogTypeDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/activityLogType", result);
     }

     // PUT: api/ActivityLogType/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateActivityLogType(Id, JsonConvert.DeserializeObject<ActivityLogTypeDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/ActivityLogType/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteActivityLogType(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
