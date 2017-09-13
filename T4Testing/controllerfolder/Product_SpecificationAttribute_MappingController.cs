using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/product_SpecificationAttribute_Mapping")]
   public class Product_SpecificationAttribute_MappingController : ApiController
   {
     IProduct_SpecificationAttribute_MappingDTOService _service;

     public Product_SpecificationAttribute_MappingController(IProduct_SpecificationAttribute_MappingDTOService service)
     {
        this._service = service;
     }

     // GET: api/Product_SpecificationAttribute_Mapping
     [Route("")]
     public IEnumerable<Product_SpecificationAttribute_MappingDTO> Get()
     {
        return _service.GetAllProduct_SpecificationAttribute_Mapping();
     }

     // GET: api/Product_SpecificationAttribute_Mapping/5
     [Route("{Id:int}")]
     public IHttpActionResult GetProduct_SpecificationAttribute_Mapping(int Id)
     {
        var product_SpecificationAttribute_Mapping = _service.GetProduct_SpecificationAttribute_Mapping(Id);
        if (product_SpecificationAttribute_Mapping == null)
        {
          return NotFound();
        }
        return Ok(product_SpecificationAttribute_Mapping);
     }

     // POST: api/Product_SpecificationAttribute_Mapping
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertProduct_SpecificationAttribute_Mapping(JsonConvert.DeserializeObject<Product_SpecificationAttribute_MappingDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/product_SpecificationAttribute_Mapping", result);
     }

     // PUT: api/Product_SpecificationAttribute_Mapping/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateProduct_SpecificationAttribute_Mapping(Id, JsonConvert.DeserializeObject<Product_SpecificationAttribute_MappingDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Product_SpecificationAttribute_Mapping/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteProduct_SpecificationAttribute_Mapping(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
