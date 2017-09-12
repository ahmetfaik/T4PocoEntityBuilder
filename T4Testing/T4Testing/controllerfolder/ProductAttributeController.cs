using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/productAttribute")]
   public class ProductAttributeController : ApiController
   {
     IProductAttributeDTOService _service;

     public ProductAttributeController(IProductAttributeDTOService service)
     {
        this._service = service;
     }

     // GET: api/ProductAttribute
     [Route("")]
     public IEnumerable<ProductAttributeDTO> Get()
     {
        return _service.GetAllProductAttribute();
     }

     // GET: api/ProductAttribute/5
     [Route("{Id:int}")]
     public IHttpActionResult GetProductAttribute(int Id)
     {
        var productAttribute = _service.GetProductAttribute(Id);
        if (productAttribute == null)
        {
          return NotFound();
        }
        return Ok(productAttribute);
     }

     // POST: api/ProductAttribute
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertProductAttribute(JsonConvert.DeserializeObject<ProductAttributeDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/productAttribute", result);
     }

     // PUT: api/ProductAttribute/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateProductAttribute(Id, JsonConvert.DeserializeObject<ProductAttributeDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/ProductAttribute/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteProductAttribute(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
