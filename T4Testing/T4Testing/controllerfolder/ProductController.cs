using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/product")]
   public class ProductController : ApiController
   {
     IProductDTOService _service;

     public ProductController(IProductDTOService service)
     {
        this._service = service;
     }

     // GET: api/Product
     [Route("")]
     public IEnumerable<ProductDTO> Get()
     {
        return _service.GetAllProduct();
     }

     // GET: api/Product/5
     [Route("{Id:int}")]
     public IHttpActionResult GetProduct(int Id)
     {
        var product = _service.GetProduct(Id);
        if (product == null)
        {
          return NotFound();
        }
        return Ok(product);
     }

     // POST: api/Product
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertProduct(JsonConvert.DeserializeObject<ProductDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/product", result);
     }

     // PUT: api/Product/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateProduct(Id, JsonConvert.DeserializeObject<ProductDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Product/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteProduct(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
