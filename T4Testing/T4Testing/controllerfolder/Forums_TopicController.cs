using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/forums_Topic")]
   public class Forums_TopicController : ApiController
   {
     IForums_TopicDTOService _service;

     public Forums_TopicController(IForums_TopicDTOService service)
     {
        this._service = service;
     }

     // GET: api/Forums_Topic
     [Route("")]
     public IEnumerable<Forums_TopicDTO> Get()
     {
        return _service.GetAllForums_Topic();
     }

     // GET: api/Forums_Topic/5
     [Route("{Id:int}")]
     public IHttpActionResult GetForums_Topic(int Id)
     {
        var forums_Topic = _service.GetForums_Topic(Id);
        if (forums_Topic == null)
        {
          return NotFound();
        }
        return Ok(forums_Topic);
     }

     // POST: api/Forums_Topic
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertForums_Topic(JsonConvert.DeserializeObject<Forums_TopicDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/forums_Topic", result);
     }

     // PUT: api/Forums_Topic/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateForums_Topic(Id, JsonConvert.DeserializeObject<Forums_TopicDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Forums_Topic/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteForums_Topic(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
