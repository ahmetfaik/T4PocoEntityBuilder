using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/discount_AppliedToProducts")]
   public class Discount_AppliedToProductsController : ApiController
   {
     IDiscount_AppliedToProductsDTOService _service;

     public Discount_AppliedToProductsController(IDiscount_AppliedToProductsDTOService service)
     {
        this._service = service;
     }

     // GET: api/Discount_AppliedToProducts
     [Route("")]
     public IEnumerable<Discount_AppliedToProductsDTO> Get()
     {
        return _service.GetAllDiscount_AppliedToProducts();
     }

     // GET: api/Discount_AppliedToProducts/5
     [Route("{Discount_Id:int}/{Product_Id:int}")]
     public IHttpActionResult GetDiscount_AppliedToProducts(int Discount_Id, int Product_Id)
     {
        var discount_AppliedToProducts = _service.GetDiscount_AppliedToProducts(Discount_Id, Product_Id);
        if (discount_AppliedToProducts == null)
        {
          return NotFound();
        }
        return Ok(discount_AppliedToProducts);
     }

     // POST: api/Discount_AppliedToProducts
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertDiscount_AppliedToProducts(JsonConvert.DeserializeObject<Discount_AppliedToProductsDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/discount_AppliedToProducts", result);
     }

     // PUT: api/Discount_AppliedToProducts/5
     [Route("{Discount_Id:int}/{Product_Id:int}")]
     public IHttpActionResult Put(int Discount_Id, int Product_Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateDiscount_AppliedToProducts(Discount_Id, Product_Id, JsonConvert.DeserializeObject<Discount_AppliedToProductsDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Discount_AppliedToProducts/5
    [Route("{Discount_Id:int}/{Product_Id:int}")]
    public IHttpActionResult Delete(int Discount_Id, int Product_Id)
    {
       var result = _service.DeleteDiscount_AppliedToProducts(Discount_Id, Product_Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
