using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/relatedProduct")]
   public class RelatedProductController : ApiController
   {
     IRelatedProductDTOService _service;

     public RelatedProductController(IRelatedProductDTOService service)
     {
        this._service = service;
     }

     // GET: api/RelatedProduct
     [Route("")]
     public IEnumerable<RelatedProductDTO> Get()
     {
        return _service.GetAllRelatedProduct();
     }

     // GET: api/RelatedProduct/5
     [Route("{Id:int}")]
     public IHttpActionResult GetRelatedProduct(int Id)
     {
        var relatedProduct = _service.GetRelatedProduct(Id);
        if (relatedProduct == null)
        {
          return NotFound();
        }
        return Ok(relatedProduct);
     }

     // POST: api/RelatedProduct
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertRelatedProduct(JsonConvert.DeserializeObject<RelatedProductDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/relatedProduct", result);
     }

     // PUT: api/RelatedProduct/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateRelatedProduct(Id, JsonConvert.DeserializeObject<RelatedProductDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/RelatedProduct/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteRelatedProduct(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
