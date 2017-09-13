using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/product_Manufacturer_Mapping")]
   public class Product_Manufacturer_MappingController : ApiController
   {
     IProduct_Manufacturer_MappingDTOService _service;

     public Product_Manufacturer_MappingController(IProduct_Manufacturer_MappingDTOService service)
     {
        this._service = service;
     }

     // GET: api/Product_Manufacturer_Mapping
     [Route("")]
     public IEnumerable<Product_Manufacturer_MappingDTO> Get()
     {
        return _service.GetAllProduct_Manufacturer_Mapping();
     }

     // GET: api/Product_Manufacturer_Mapping/5
     [Route("{Id:int}")]
     public IHttpActionResult GetProduct_Manufacturer_Mapping(int Id)
     {
        var product_Manufacturer_Mapping = _service.GetProduct_Manufacturer_Mapping(Id);
        if (product_Manufacturer_Mapping == null)
        {
          return NotFound();
        }
        return Ok(product_Manufacturer_Mapping);
     }

     // POST: api/Product_Manufacturer_Mapping
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertProduct_Manufacturer_Mapping(JsonConvert.DeserializeObject<Product_Manufacturer_MappingDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/product_Manufacturer_Mapping", result);
     }

     // PUT: api/Product_Manufacturer_Mapping/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateProduct_Manufacturer_Mapping(Id, JsonConvert.DeserializeObject<Product_Manufacturer_MappingDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Product_Manufacturer_Mapping/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteProduct_Manufacturer_Mapping(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
