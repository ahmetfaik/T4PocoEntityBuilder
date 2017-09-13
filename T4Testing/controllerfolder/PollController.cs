using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/poll")]
   public class PollController : ApiController
   {
     IPollDTOService _service;

     public PollController(IPollDTOService service)
     {
        this._service = service;
     }

     // GET: api/Poll
     [Route("")]
     public IEnumerable<PollDTO> Get()
     {
        return _service.GetAllPoll();
     }

     // GET: api/Poll/5
     [Route("{Id:int}")]
     public IHttpActionResult GetPoll(int Id)
     {
        var poll = _service.GetPoll(Id);
        if (poll == null)
        {
          return NotFound();
        }
        return Ok(poll);
     }

     // POST: api/Poll
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertPoll(JsonConvert.DeserializeObject<PollDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/poll", result);
     }

     // PUT: api/Poll/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdatePoll(Id, JsonConvert.DeserializeObject<PollDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Poll/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeletePoll(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
