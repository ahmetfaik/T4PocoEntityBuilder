using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/topicTemplate")]
   public class TopicTemplateController : ApiController
   {
     ITopicTemplateDTOService _service;

     public TopicTemplateController(ITopicTemplateDTOService service)
     {
        this._service = service;
     }

     // GET: api/TopicTemplate
     [Route("")]
     public IEnumerable<TopicTemplateDTO> Get()
     {
        return _service.GetAllTopicTemplate();
     }

     // GET: api/TopicTemplate/5
     [Route("{Id:int}")]
     public IHttpActionResult GetTopicTemplate(int Id)
     {
        var topicTemplate = _service.GetTopicTemplate(Id);
        if (topicTemplate == null)
        {
          return NotFound();
        }
        return Ok(topicTemplate);
     }

     // POST: api/TopicTemplate
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertTopicTemplate(JsonConvert.DeserializeObject<TopicTemplateDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/topicTemplate", result);
     }

     // PUT: api/TopicTemplate/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateTopicTemplate(Id, JsonConvert.DeserializeObject<TopicTemplateDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/TopicTemplate/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteTopicTemplate(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
