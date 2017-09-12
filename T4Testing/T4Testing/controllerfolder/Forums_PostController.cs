using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/forums_Post")]
   public class Forums_PostController : ApiController
   {
     IForums_PostDTOService _service;

     public Forums_PostController(IForums_PostDTOService service)
     {
        this._service = service;
     }

     // GET: api/Forums_Post
     [Route("")]
     public IEnumerable<Forums_PostDTO> Get()
     {
        return _service.GetAllForums_Post();
     }

     // GET: api/Forums_Post/5
     [Route("{Id:int}")]
     public IHttpActionResult GetForums_Post(int Id)
     {
        var forums_Post = _service.GetForums_Post(Id);
        if (forums_Post == null)
        {
          return NotFound();
        }
        return Ok(forums_Post);
     }

     // POST: api/Forums_Post
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertForums_Post(JsonConvert.DeserializeObject<Forums_PostDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/forums_Post", result);
     }

     // PUT: api/Forums_Post/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateForums_Post(Id, JsonConvert.DeserializeObject<Forums_PostDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Forums_Post/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteForums_Post(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
