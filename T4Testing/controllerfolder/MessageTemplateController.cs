using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/messageTemplate")]
   public class MessageTemplateController : ApiController
   {
     IMessageTemplateDTOService _service;

     public MessageTemplateController(IMessageTemplateDTOService service)
     {
        this._service = service;
     }

     // GET: api/MessageTemplate
     [Route("")]
     public IEnumerable<MessageTemplateDTO> Get()
     {
        return _service.GetAllMessageTemplate();
     }

     // GET: api/MessageTemplate/5
     [Route("{Id:int}")]
     public IHttpActionResult GetMessageTemplate(int Id)
     {
        var messageTemplate = _service.GetMessageTemplate(Id);
        if (messageTemplate == null)
        {
          return NotFound();
        }
        return Ok(messageTemplate);
     }

     // POST: api/MessageTemplate
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertMessageTemplate(JsonConvert.DeserializeObject<MessageTemplateDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/messageTemplate", result);
     }

     // PUT: api/MessageTemplate/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateMessageTemplate(Id, JsonConvert.DeserializeObject<MessageTemplateDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/MessageTemplate/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteMessageTemplate(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
