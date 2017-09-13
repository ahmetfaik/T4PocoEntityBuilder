using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/productAttributeValue")]
   public class ProductAttributeValueController : ApiController
   {
     IProductAttributeValueDTOService _service;

     public ProductAttributeValueController(IProductAttributeValueDTOService service)
     {
        this._service = service;
     }

     // GET: api/ProductAttributeValue
     [Route("")]
     public IEnumerable<ProductAttributeValueDTO> Get()
     {
        return _service.GetAllProductAttributeValue();
     }

     // GET: api/ProductAttributeValue/5
     [Route("{Id:int}")]
     public IHttpActionResult GetProductAttributeValue(int Id)
     {
        var productAttributeValue = _service.GetProductAttributeValue(Id);
        if (productAttributeValue == null)
        {
          return NotFound();
        }
        return Ok(productAttributeValue);
     }

     // POST: api/ProductAttributeValue
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertProductAttributeValue(JsonConvert.DeserializeObject<ProductAttributeValueDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/productAttributeValue", result);
     }

     // PUT: api/ProductAttributeValue/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateProductAttributeValue(Id, JsonConvert.DeserializeObject<ProductAttributeValueDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/ProductAttributeValue/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteProductAttributeValue(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
