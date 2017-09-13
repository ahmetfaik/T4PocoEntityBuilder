using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/crossSellProduct")]
   public class CrossSellProductController : ApiController
   {
     ICrossSellProductDTOService _service;

     public CrossSellProductController(ICrossSellProductDTOService service)
     {
        this._service = service;
     }

     // GET: api/CrossSellProduct
     [Route("")]
     public IEnumerable<CrossSellProductDTO> Get()
     {
        return _service.GetAllCrossSellProduct();
     }

     // GET: api/CrossSellProduct/5
     [Route("{Id:int}")]
     public IHttpActionResult GetCrossSellProduct(int Id)
     {
        var crossSellProduct = _service.GetCrossSellProduct(Id);
        if (crossSellProduct == null)
        {
          return NotFound();
        }
        return Ok(crossSellProduct);
     }

     // POST: api/CrossSellProduct
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertCrossSellProduct(JsonConvert.DeserializeObject<CrossSellProductDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/crossSellProduct", result);
     }

     // PUT: api/CrossSellProduct/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateCrossSellProduct(Id, JsonConvert.DeserializeObject<CrossSellProductDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/CrossSellProduct/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteCrossSellProduct(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
