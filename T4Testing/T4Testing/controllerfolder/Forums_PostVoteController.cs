using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/forums_PostVote")]
   public class Forums_PostVoteController : ApiController
   {
     IForums_PostVoteDTOService _service;

     public Forums_PostVoteController(IForums_PostVoteDTOService service)
     {
        this._service = service;
     }

     // GET: api/Forums_PostVote
     [Route("")]
     public IEnumerable<Forums_PostVoteDTO> Get()
     {
        return _service.GetAllForums_PostVote();
     }

     // GET: api/Forums_PostVote/5
     [Route("{Id:int}")]
     public IHttpActionResult GetForums_PostVote(int Id)
     {
        var forums_PostVote = _service.GetForums_PostVote(Id);
        if (forums_PostVote == null)
        {
          return NotFound();
        }
        return Ok(forums_PostVote);
     }

     // POST: api/Forums_PostVote
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertForums_PostVote(JsonConvert.DeserializeObject<Forums_PostVoteDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/forums_PostVote", result);
     }

     // PUT: api/Forums_PostVote/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateForums_PostVote(Id, JsonConvert.DeserializeObject<Forums_PostVoteDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Forums_PostVote/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteForums_PostVote(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
