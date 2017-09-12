using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/forums_PrivateMessage")]
   public class Forums_PrivateMessageController : ApiController
   {
     IForums_PrivateMessageDTOService _service;

     public Forums_PrivateMessageController(IForums_PrivateMessageDTOService service)
     {
        this._service = service;
     }

     // GET: api/Forums_PrivateMessage
     [Route("")]
     public IEnumerable<Forums_PrivateMessageDTO> Get()
     {
        return _service.GetAllForums_PrivateMessage();
     }

     // GET: api/Forums_PrivateMessage/5
     [Route("{Id:int}")]
     public IHttpActionResult GetForums_PrivateMessage(int Id)
     {
        var forums_PrivateMessage = _service.GetForums_PrivateMessage(Id);
        if (forums_PrivateMessage == null)
        {
          return NotFound();
        }
        return Ok(forums_PrivateMessage);
     }

     // POST: api/Forums_PrivateMessage
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertForums_PrivateMessage(JsonConvert.DeserializeObject<Forums_PrivateMessageDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/forums_PrivateMessage", result);
     }

     // PUT: api/Forums_PrivateMessage/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateForums_PrivateMessage(Id, JsonConvert.DeserializeObject<Forums_PrivateMessageDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Forums_PrivateMessage/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteForums_PrivateMessage(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
