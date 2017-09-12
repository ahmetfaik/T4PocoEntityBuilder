using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/discountUsageHistory")]
   public class DiscountUsageHistoryController : ApiController
   {
     IDiscountUsageHistoryDTOService _service;

     public DiscountUsageHistoryController(IDiscountUsageHistoryDTOService service)
     {
        this._service = service;
     }

     // GET: api/DiscountUsageHistory
     [Route("")]
     public IEnumerable<DiscountUsageHistoryDTO> Get()
     {
        return _service.GetAllDiscountUsageHistory();
     }

     // GET: api/DiscountUsageHistory/5
     [Route("{Id:int}")]
     public IHttpActionResult GetDiscountUsageHistory(int Id)
     {
        var discountUsageHistory = _service.GetDiscountUsageHistory(Id);
        if (discountUsageHistory == null)
        {
          return NotFound();
        }
        return Ok(discountUsageHistory);
     }

     // POST: api/DiscountUsageHistory
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertDiscountUsageHistory(JsonConvert.DeserializeObject<DiscountUsageHistoryDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/discountUsageHistory", result);
     }

     // PUT: api/DiscountUsageHistory/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateDiscountUsageHistory(Id, JsonConvert.DeserializeObject<DiscountUsageHistoryDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/DiscountUsageHistory/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteDiscountUsageHistory(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
