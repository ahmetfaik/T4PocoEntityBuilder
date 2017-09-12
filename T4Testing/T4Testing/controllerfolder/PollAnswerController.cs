using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/pollAnswer")]
   public class PollAnswerController : ApiController
   {
     IPollAnswerDTOService _service;

     public PollAnswerController(IPollAnswerDTOService service)
     {
        this._service = service;
     }

     // GET: api/PollAnswer
     [Route("")]
     public IEnumerable<PollAnswerDTO> Get()
     {
        return _service.GetAllPollAnswer();
     }

     // GET: api/PollAnswer/5
     [Route("{Id:int}")]
     public IHttpActionResult GetPollAnswer(int Id)
     {
        var pollAnswer = _service.GetPollAnswer(Id);
        if (pollAnswer == null)
        {
          return NotFound();
        }
        return Ok(pollAnswer);
     }

     // POST: api/PollAnswer
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertPollAnswer(JsonConvert.DeserializeObject<PollAnswerDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/pollAnswer", result);
     }

     // PUT: api/PollAnswer/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdatePollAnswer(Id, JsonConvert.DeserializeObject<PollAnswerDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/PollAnswer/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeletePollAnswer(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
