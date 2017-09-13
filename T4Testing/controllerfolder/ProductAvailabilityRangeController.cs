using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/productAvailabilityRange")]
   public class ProductAvailabilityRangeController : ApiController
   {
     IProductAvailabilityRangeDTOService _service;

     public ProductAvailabilityRangeController(IProductAvailabilityRangeDTOService service)
     {
        this._service = service;
     }

     // GET: api/ProductAvailabilityRange
     [Route("")]
     public IEnumerable<ProductAvailabilityRangeDTO> Get()
     {
        return _service.GetAllProductAvailabilityRange();
     }

     // GET: api/ProductAvailabilityRange/5
     [Route("{Id:int}")]
     public IHttpActionResult GetProductAvailabilityRange(int Id)
     {
        var productAvailabilityRange = _service.GetProductAvailabilityRange(Id);
        if (productAvailabilityRange == null)
        {
          return NotFound();
        }
        return Ok(productAvailabilityRange);
     }

     // POST: api/ProductAvailabilityRange
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertProductAvailabilityRange(JsonConvert.DeserializeObject<ProductAvailabilityRangeDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/productAvailabilityRange", result);
     }

     // PUT: api/ProductAvailabilityRange/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateProductAvailabilityRange(Id, JsonConvert.DeserializeObject<ProductAvailabilityRangeDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/ProductAvailabilityRange/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteProductAvailabilityRange(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
