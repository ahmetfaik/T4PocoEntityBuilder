using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/rewardPointsHistory")]
   public class RewardPointsHistoryController : ApiController
   {
     IRewardPointsHistoryDTOService _service;

     public RewardPointsHistoryController(IRewardPointsHistoryDTOService service)
     {
        this._service = service;
     }

     // GET: api/RewardPointsHistory
     [Route("")]
     public IEnumerable<RewardPointsHistoryDTO> Get()
     {
        return _service.GetAllRewardPointsHistory();
     }

     // GET: api/RewardPointsHistory/5
     [Route("{Id:int}")]
     public IHttpActionResult GetRewardPointsHistory(int Id)
     {
        var rewardPointsHistory = _service.GetRewardPointsHistory(Id);
        if (rewardPointsHistory == null)
        {
          return NotFound();
        }
        return Ok(rewardPointsHistory);
     }

     // POST: api/RewardPointsHistory
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertRewardPointsHistory(JsonConvert.DeserializeObject<RewardPointsHistoryDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/rewardPointsHistory", result);
     }

     // PUT: api/RewardPointsHistory/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateRewardPointsHistory(Id, JsonConvert.DeserializeObject<RewardPointsHistoryDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/RewardPointsHistory/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteRewardPointsHistory(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
