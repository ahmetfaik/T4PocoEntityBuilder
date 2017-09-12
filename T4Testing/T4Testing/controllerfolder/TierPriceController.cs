using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/tierPrice")]
   public class TierPriceController : ApiController
   {
     ITierPriceDTOService _service;

     public TierPriceController(ITierPriceDTOService service)
     {
        this._service = service;
     }

     // GET: api/TierPrice
     [Route("")]
     public IEnumerable<TierPriceDTO> Get()
     {
        return _service.GetAllTierPrice();
     }

     // GET: api/TierPrice/5
     [Route("{Id:int}")]
     public IHttpActionResult GetTierPrice(int Id)
     {
        var tierPrice = _service.GetTierPrice(Id);
        if (tierPrice == null)
        {
          return NotFound();
        }
        return Ok(tierPrice);
     }

     // POST: api/TierPrice
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertTierPrice(JsonConvert.DeserializeObject<TierPriceDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/tierPrice", result);
     }

     // PUT: api/TierPrice/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateTierPrice(Id, JsonConvert.DeserializeObject<TierPriceDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/TierPrice/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteTierPrice(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
