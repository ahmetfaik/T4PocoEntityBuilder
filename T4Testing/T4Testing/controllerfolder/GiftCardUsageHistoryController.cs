using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/giftCardUsageHistory")]
   public class GiftCardUsageHistoryController : ApiController
   {
     IGiftCardUsageHistoryDTOService _service;

     public GiftCardUsageHistoryController(IGiftCardUsageHistoryDTOService service)
     {
        this._service = service;
     }

     // GET: api/GiftCardUsageHistory
     [Route("")]
     public IEnumerable<GiftCardUsageHistoryDTO> Get()
     {
        return _service.GetAllGiftCardUsageHistory();
     }

     // GET: api/GiftCardUsageHistory/5
     [Route("{Id:int}")]
     public IHttpActionResult GetGiftCardUsageHistory(int Id)
     {
        var giftCardUsageHistory = _service.GetGiftCardUsageHistory(Id);
        if (giftCardUsageHistory == null)
        {
          return NotFound();
        }
        return Ok(giftCardUsageHistory);
     }

     // POST: api/GiftCardUsageHistory
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertGiftCardUsageHistory(JsonConvert.DeserializeObject<GiftCardUsageHistoryDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/giftCardUsageHistory", result);
     }

     // PUT: api/GiftCardUsageHistory/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateGiftCardUsageHistory(Id, JsonConvert.DeserializeObject<GiftCardUsageHistoryDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/GiftCardUsageHistory/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteGiftCardUsageHistory(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
