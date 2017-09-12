using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/stockQuantityHistory")]
   public class StockQuantityHistoryController : ApiController
   {
     IStockQuantityHistoryDTOService _service;

     public StockQuantityHistoryController(IStockQuantityHistoryDTOService service)
     {
        this._service = service;
     }

     // GET: api/StockQuantityHistory
     [Route("")]
     public IEnumerable<StockQuantityHistoryDTO> Get()
     {
        return _service.GetAllStockQuantityHistory();
     }

     // GET: api/StockQuantityHistory/5
     [Route("{Id:int}")]
     public IHttpActionResult GetStockQuantityHistory(int Id)
     {
        var stockQuantityHistory = _service.GetStockQuantityHistory(Id);
        if (stockQuantityHistory == null)
        {
          return NotFound();
        }
        return Ok(stockQuantityHistory);
     }

     // POST: api/StockQuantityHistory
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertStockQuantityHistory(JsonConvert.DeserializeObject<StockQuantityHistoryDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/stockQuantityHistory", result);
     }

     // PUT: api/StockQuantityHistory/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateStockQuantityHistory(Id, JsonConvert.DeserializeObject<StockQuantityHistoryDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/StockQuantityHistory/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteStockQuantityHistory(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
