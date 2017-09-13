using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/productReview")]
   public class ProductReviewController : ApiController
   {
     IProductReviewDTOService _service;

     public ProductReviewController(IProductReviewDTOService service)
     {
        this._service = service;
     }

     // GET: api/ProductReview
     [Route("")]
     public IEnumerable<ProductReviewDTO> Get()
     {
        return _service.GetAllProductReview();
     }

     // GET: api/ProductReview/5
     [Route("{Id:int}")]
     public IHttpActionResult GetProductReview(int Id)
     {
        var productReview = _service.GetProductReview(Id);
        if (productReview == null)
        {
          return NotFound();
        }
        return Ok(productReview);
     }

     // POST: api/ProductReview
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertProductReview(JsonConvert.DeserializeObject<ProductReviewDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/productReview", result);
     }

     // PUT: api/ProductReview/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateProductReview(Id, JsonConvert.DeserializeObject<ProductReviewDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/ProductReview/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteProductReview(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
