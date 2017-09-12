using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/productAttributeCombination")]
   public class ProductAttributeCombinationController : ApiController
   {
     IProductAttributeCombinationDTOService _service;

     public ProductAttributeCombinationController(IProductAttributeCombinationDTOService service)
     {
        this._service = service;
     }

     // GET: api/ProductAttributeCombination
     [Route("")]
     public IEnumerable<ProductAttributeCombinationDTO> Get()
     {
        return _service.GetAllProductAttributeCombination();
     }

     // GET: api/ProductAttributeCombination/5
     [Route("{Id:int}")]
     public IHttpActionResult GetProductAttributeCombination(int Id)
     {
        var productAttributeCombination = _service.GetProductAttributeCombination(Id);
        if (productAttributeCombination == null)
        {
          return NotFound();
        }
        return Ok(productAttributeCombination);
     }

     // POST: api/ProductAttributeCombination
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertProductAttributeCombination(JsonConvert.DeserializeObject<ProductAttributeCombinationDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/productAttributeCombination", result);
     }

     // PUT: api/ProductAttributeCombination/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateProductAttributeCombination(Id, JsonConvert.DeserializeObject<ProductAttributeCombinationDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/ProductAttributeCombination/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteProductAttributeCombination(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
