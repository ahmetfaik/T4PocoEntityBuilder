using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/productTag")]
   public class ProductTagController : ApiController
   {
     IProductTagDTOService _service;

     public ProductTagController(IProductTagDTOService service)
     {
        this._service = service;
     }

     // GET: api/ProductTag
     [Route("")]
     public IEnumerable<ProductTagDTO> Get()
     {
        return _service.GetAllProductTag();
     }

     // GET: api/ProductTag/5
     [Route("{Id:int}")]
     public IHttpActionResult GetProductTag(int Id)
     {
        var productTag = _service.GetProductTag(Id);
        if (productTag == null)
        {
          return NotFound();
        }
        return Ok(productTag);
     }

     // POST: api/ProductTag
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertProductTag(JsonConvert.DeserializeObject<ProductTagDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/productTag", result);
     }

     // PUT: api/ProductTag/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateProductTag(Id, JsonConvert.DeserializeObject<ProductTagDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/ProductTag/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteProductTag(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
