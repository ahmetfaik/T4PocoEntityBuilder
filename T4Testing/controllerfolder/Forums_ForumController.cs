using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/forums_Forum")]
   public class Forums_ForumController : ApiController
   {
     IForums_ForumDTOService _service;

     public Forums_ForumController(IForums_ForumDTOService service)
     {
        this._service = service;
     }

     // GET: api/Forums_Forum
     [Route("")]
     public IEnumerable<Forums_ForumDTO> Get()
     {
        return _service.GetAllForums_Forum();
     }

     // GET: api/Forums_Forum/5
     [Route("{Id:int}")]
     public IHttpActionResult GetForums_Forum(int Id)
     {
        var forums_Forum = _service.GetForums_Forum(Id);
        if (forums_Forum == null)
        {
          return NotFound();
        }
        return Ok(forums_Forum);
     }

     // POST: api/Forums_Forum
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertForums_Forum(JsonConvert.DeserializeObject<Forums_ForumDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/forums_Forum", result);
     }

     // PUT: api/Forums_Forum/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateForums_Forum(Id, JsonConvert.DeserializeObject<Forums_ForumDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Forums_Forum/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteForums_Forum(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
