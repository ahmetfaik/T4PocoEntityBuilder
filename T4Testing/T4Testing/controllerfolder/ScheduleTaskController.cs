using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/scheduleTask")]
   public class ScheduleTaskController : ApiController
   {
     IScheduleTaskDTOService _service;

     public ScheduleTaskController(IScheduleTaskDTOService service)
     {
        this._service = service;
     }

     // GET: api/ScheduleTask
     [Route("")]
     public IEnumerable<ScheduleTaskDTO> Get()
     {
        return _service.GetAllScheduleTask();
     }

     // GET: api/ScheduleTask/5
     [Route("{Id:int}")]
     public IHttpActionResult GetScheduleTask(int Id)
     {
        var scheduleTask = _service.GetScheduleTask(Id);
        if (scheduleTask == null)
        {
          return NotFound();
        }
        return Ok(scheduleTask);
     }

     // POST: api/ScheduleTask
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertScheduleTask(JsonConvert.DeserializeObject<ScheduleTaskDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/scheduleTask", result);
     }

     // PUT: api/ScheduleTask/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateScheduleTask(Id, JsonConvert.DeserializeObject<ScheduleTaskDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/ScheduleTask/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteScheduleTask(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
