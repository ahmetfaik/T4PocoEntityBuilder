using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/discount")]
   public class DiscountController : ApiController
   {
     IDiscountDTOService _service;

     public DiscountController(IDiscountDTOService service)
     {
        this._service = service;
     }

     // GET: api/Discount
     [Route("")]
     public IEnumerable<DiscountDTO> Get()
     {
        return _service.GetAllDiscount();
     }

     // GET: api/Discount/5
     [Route("{Id:int}")]
     public IHttpActionResult GetDiscount(int Id)
     {
        var discount = _service.GetDiscount(Id);
        if (discount == null)
        {
          return NotFound();
        }
        return Ok(discount);
     }

     // POST: api/Discount
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertDiscount(JsonConvert.DeserializeObject<DiscountDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/discount", result);
     }

     // PUT: api/Discount/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateDiscount(Id, JsonConvert.DeserializeObject<DiscountDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Discount/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteDiscount(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
