using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/product_Picture_Mapping")]
   public class Product_Picture_MappingController : ApiController
   {
     IProduct_Picture_MappingDTOService _service;

     public Product_Picture_MappingController(IProduct_Picture_MappingDTOService service)
     {
        this._service = service;
     }

     // GET: api/Product_Picture_Mapping
     [Route("")]
     public IEnumerable<Product_Picture_MappingDTO> Get()
     {
        return _service.GetAllProduct_Picture_Mapping();
     }

     // GET: api/Product_Picture_Mapping/5
     [Route("{Id:int}")]
     public IHttpActionResult GetProduct_Picture_Mapping(int Id)
     {
        var product_Picture_Mapping = _service.GetProduct_Picture_Mapping(Id);
        if (product_Picture_Mapping == null)
        {
          return NotFound();
        }
        return Ok(product_Picture_Mapping);
     }

     // POST: api/Product_Picture_Mapping
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertProduct_Picture_Mapping(JsonConvert.DeserializeObject<Product_Picture_MappingDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/product_Picture_Mapping", result);
     }

     // PUT: api/Product_Picture_Mapping/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateProduct_Picture_Mapping(Id, JsonConvert.DeserializeObject<Product_Picture_MappingDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Product_Picture_Mapping/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteProduct_Picture_Mapping(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
