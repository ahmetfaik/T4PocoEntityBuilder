using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/product_Category_Mapping")]
   public class Product_Category_MappingController : ApiController
   {
     IProduct_Category_MappingDTOService _service;

     public Product_Category_MappingController(IProduct_Category_MappingDTOService service)
     {
        this._service = service;
     }

     // GET: api/Product_Category_Mapping
     [Route("")]
     public IEnumerable<Product_Category_MappingDTO> Get()
     {
        return _service.GetAllProduct_Category_Mapping();
     }

     // GET: api/Product_Category_Mapping/5
     [Route("{Id:int}")]
     public IHttpActionResult GetProduct_Category_Mapping(int Id)
     {
        var product_Category_Mapping = _service.GetProduct_Category_Mapping(Id);
        if (product_Category_Mapping == null)
        {
          return NotFound();
        }
        return Ok(product_Category_Mapping);
     }

     // POST: api/Product_Category_Mapping
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertProduct_Category_Mapping(JsonConvert.DeserializeObject<Product_Category_MappingDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/product_Category_Mapping", result);
     }

     // PUT: api/Product_Category_Mapping/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateProduct_Category_Mapping(Id, JsonConvert.DeserializeObject<Product_Category_MappingDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Product_Category_Mapping/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteProduct_Category_Mapping(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
