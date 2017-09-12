using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/checkoutAttributeValue")]
   public class CheckoutAttributeValueController : ApiController
   {
     ICheckoutAttributeValueDTOService _service;

     public CheckoutAttributeValueController(ICheckoutAttributeValueDTOService service)
     {
        this._service = service;
     }

     // GET: api/CheckoutAttributeValue
     [Route("")]
     public IEnumerable<CheckoutAttributeValueDTO> Get()
     {
        return _service.GetAllCheckoutAttributeValue();
     }

     // GET: api/CheckoutAttributeValue/5
     [Route("{Id:int}")]
     public IHttpActionResult GetCheckoutAttributeValue(int Id)
     {
        var checkoutAttributeValue = _service.GetCheckoutAttributeValue(Id);
        if (checkoutAttributeValue == null)
        {
          return NotFound();
        }
        return Ok(checkoutAttributeValue);
     }

     // POST: api/CheckoutAttributeValue
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertCheckoutAttributeValue(JsonConvert.DeserializeObject<CheckoutAttributeValueDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/checkoutAttributeValue", result);
     }

     // PUT: api/CheckoutAttributeValue/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateCheckoutAttributeValue(Id, JsonConvert.DeserializeObject<CheckoutAttributeValueDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/CheckoutAttributeValue/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteCheckoutAttributeValue(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
