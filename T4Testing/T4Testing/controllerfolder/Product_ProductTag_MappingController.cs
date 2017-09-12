using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/product_ProductTag_Mapping")]
   public class Product_ProductTag_MappingController : ApiController
   {
     IProduct_ProductTag_MappingDTOService _service;

     public Product_ProductTag_MappingController(IProduct_ProductTag_MappingDTOService service)
     {
        this._service = service;
     }

     // GET: api/Product_ProductTag_Mapping
     [Route("")]
     public IEnumerable<Product_ProductTag_MappingDTO> Get()
     {
        return _service.GetAllProduct_ProductTag_Mapping();
     }

     // GET: api/Product_ProductTag_Mapping/5
     [Route("{Product_Id:int}/{ProductTag_Id:int}")]
     public IHttpActionResult GetProduct_ProductTag_Mapping(int Product_Id, int ProductTag_Id)
     {
        var product_ProductTag_Mapping = _service.GetProduct_ProductTag_Mapping(Product_Id, ProductTag_Id);
        if (product_ProductTag_Mapping == null)
        {
          return NotFound();
        }
        return Ok(product_ProductTag_Mapping);
     }

     // POST: api/Product_ProductTag_Mapping
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertProduct_ProductTag_Mapping(JsonConvert.DeserializeObject<Product_ProductTag_MappingDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/product_ProductTag_Mapping", result);
     }

     // PUT: api/Product_ProductTag_Mapping/5
     [Route("{Product_Id:int}/{ProductTag_Id:int}")]
     public IHttpActionResult Put(int Product_Id, int ProductTag_Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateProduct_ProductTag_Mapping(Product_Id, ProductTag_Id, JsonConvert.DeserializeObject<Product_ProductTag_MappingDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Product_ProductTag_Mapping/5
    [Route("{Product_Id:int}/{ProductTag_Id:int}")]
    public IHttpActionResult Delete(int Product_Id, int ProductTag_Id)
    {
       var result = _service.DeleteProduct_ProductTag_Mapping(Product_Id, ProductTag_Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
