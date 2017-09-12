using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/shippingMethod")]
   public class ShippingMethodController : ApiController
   {
     IShippingMethodDTOService _service;

     public ShippingMethodController(IShippingMethodDTOService service)
     {
        this._service = service;
     }

     // GET: api/ShippingMethod
     [Route("")]
     public IEnumerable<ShippingMethodDTO> Get()
     {
        return _service.GetAllShippingMethod();
     }

     // GET: api/ShippingMethod/5
     [Route("{Id:int}")]
     public IHttpActionResult GetShippingMethod(int Id)
     {
        var shippingMethod = _service.GetShippingMethod(Id);
        if (shippingMethod == null)
        {
          return NotFound();
        }
        return Ok(shippingMethod);
     }

     // POST: api/ShippingMethod
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertShippingMethod(JsonConvert.DeserializeObject<ShippingMethodDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/shippingMethod", result);
     }

     // PUT: api/ShippingMethod/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateShippingMethod(Id, JsonConvert.DeserializeObject<ShippingMethodDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/ShippingMethod/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteShippingMethod(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
