using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/product_ProductAttribute_Mapping")]
   public class Product_ProductAttribute_MappingController : ApiController
   {
     IProduct_ProductAttribute_MappingDTOService _service;

     public Product_ProductAttribute_MappingController(IProduct_ProductAttribute_MappingDTOService service)
     {
        this._service = service;
     }

     // GET: api/Product_ProductAttribute_Mapping
     [Route("")]
     public IEnumerable<Product_ProductAttribute_MappingDTO> Get()
     {
        return _service.GetAllProduct_ProductAttribute_Mapping();
     }

     // GET: api/Product_ProductAttribute_Mapping/5
     [Route("{Id:int}")]
     public IHttpActionResult GetProduct_ProductAttribute_Mapping(int Id)
     {
        var product_ProductAttribute_Mapping = _service.GetProduct_ProductAttribute_Mapping(Id);
        if (product_ProductAttribute_Mapping == null)
        {
          return NotFound();
        }
        return Ok(product_ProductAttribute_Mapping);
     }

     // POST: api/Product_ProductAttribute_Mapping
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertProduct_ProductAttribute_Mapping(JsonConvert.DeserializeObject<Product_ProductAttribute_MappingDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/product_ProductAttribute_Mapping", result);
     }

     // PUT: api/Product_ProductAttribute_Mapping/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateProduct_ProductAttribute_Mapping(Id, JsonConvert.DeserializeObject<Product_ProductAttribute_MappingDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Product_ProductAttribute_Mapping/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteProduct_ProductAttribute_Mapping(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
