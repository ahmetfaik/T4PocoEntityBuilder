using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/productReviewHelpfulness")]
   public class ProductReviewHelpfulnessController : ApiController
   {
     IProductReviewHelpfulnessDTOService _service;

     public ProductReviewHelpfulnessController(IProductReviewHelpfulnessDTOService service)
     {
        this._service = service;
     }

     // GET: api/ProductReviewHelpfulness
     [Route("")]
     public IEnumerable<ProductReviewHelpfulnessDTO> Get()
     {
        return _service.GetAllProductReviewHelpfulness();
     }

     // GET: api/ProductReviewHelpfulness/5
     [Route("{Id:int}")]
     public IHttpActionResult GetProductReviewHelpfulness(int Id)
     {
        var productReviewHelpfulness = _service.GetProductReviewHelpfulness(Id);
        if (productReviewHelpfulness == null)
        {
          return NotFound();
        }
        return Ok(productReviewHelpfulness);
     }

     // POST: api/ProductReviewHelpfulness
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertProductReviewHelpfulness(JsonConvert.DeserializeObject<ProductReviewHelpfulnessDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/productReviewHelpfulness", result);
     }

     // PUT: api/ProductReviewHelpfulness/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateProductReviewHelpfulness(Id, JsonConvert.DeserializeObject<ProductReviewHelpfulnessDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/ProductReviewHelpfulness/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteProductReviewHelpfulness(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
