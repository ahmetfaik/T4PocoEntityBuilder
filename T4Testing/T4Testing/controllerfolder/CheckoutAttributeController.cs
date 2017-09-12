using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/checkoutAttribute")]
   public class CheckoutAttributeController : ApiController
   {
     ICheckoutAttributeDTOService _service;

     public CheckoutAttributeController(ICheckoutAttributeDTOService service)
     {
        this._service = service;
     }

     // GET: api/CheckoutAttribute
     [Route("")]
     public IEnumerable<CheckoutAttributeDTO> Get()
     {
        return _service.GetAllCheckoutAttribute();
     }

     // GET: api/CheckoutAttribute/5
     [Route("{Id:int}")]
     public IHttpActionResult GetCheckoutAttribute(int Id)
     {
        var checkoutAttribute = _service.GetCheckoutAttribute(Id);
        if (checkoutAttribute == null)
        {
          return NotFound();
        }
        return Ok(checkoutAttribute);
     }

     // POST: api/CheckoutAttribute
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertCheckoutAttribute(JsonConvert.DeserializeObject<CheckoutAttributeDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/checkoutAttribute", result);
     }

     // PUT: api/CheckoutAttribute/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateCheckoutAttribute(Id, JsonConvert.DeserializeObject<CheckoutAttributeDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/CheckoutAttribute/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteCheckoutAttribute(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
