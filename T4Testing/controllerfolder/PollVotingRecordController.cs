using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/pollVotingRecord")]
   public class PollVotingRecordController : ApiController
   {
     IPollVotingRecordDTOService _service;

     public PollVotingRecordController(IPollVotingRecordDTOService service)
     {
        this._service = service;
     }

     // GET: api/PollVotingRecord
     [Route("")]
     public IEnumerable<PollVotingRecordDTO> Get()
     {
        return _service.GetAllPollVotingRecord();
     }

     // GET: api/PollVotingRecord/5
     [Route("{Id:int}")]
     public IHttpActionResult GetPollVotingRecord(int Id)
     {
        var pollVotingRecord = _service.GetPollVotingRecord(Id);
        if (pollVotingRecord == null)
        {
          return NotFound();
        }
        return Ok(pollVotingRecord);
     }

     // POST: api/PollVotingRecord
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertPollVotingRecord(JsonConvert.DeserializeObject<PollVotingRecordDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/pollVotingRecord", result);
     }

     // PUT: api/PollVotingRecord/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdatePollVotingRecord(Id, JsonConvert.DeserializeObject<PollVotingRecordDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/PollVotingRecord/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeletePollVotingRecord(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
