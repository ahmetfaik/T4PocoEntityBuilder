using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/topic")]
   public class TopicController : ApiController
   {
     ITopicDTOService _service;

     public TopicController(ITopicDTOService service)
     {
        this._service = service;
     }

     // GET: api/Topic
     [Route("")]
     public IEnumerable<TopicDTO> Get()
     {
        return _service.GetAllTopic();
     }

     // GET: api/Topic/5
     [Route("{Id:int}")]
     public IHttpActionResult GetTopic(int Id)
     {
        var topic = _service.GetTopic(Id);
        if (topic == null)
        {
          return NotFound();
        }
        return Ok(topic);
     }

     // POST: api/Topic
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertTopic(JsonConvert.DeserializeObject<TopicDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/topic", result);
     }

     // PUT: api/Topic/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateTopic(Id, JsonConvert.DeserializeObject<TopicDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Topic/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteTopic(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
