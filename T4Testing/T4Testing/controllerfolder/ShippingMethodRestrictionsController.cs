using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/shippingMethodRestrictions")]
   public class ShippingMethodRestrictionsController : ApiController
   {
     IShippingMethodRestrictionsDTOService _service;

     public ShippingMethodRestrictionsController(IShippingMethodRestrictionsDTOService service)
     {
        this._service = service;
     }

     // GET: api/ShippingMethodRestrictions
     [Route("")]
     public IEnumerable<ShippingMethodRestrictionsDTO> Get()
     {
        return _service.GetAllShippingMethodRestrictions();
     }

     // GET: api/ShippingMethodRestrictions/5
     [Route("{ShippingMethod_Id:int}/{Country_Id:int}")]
     public IHttpActionResult GetShippingMethodRestrictions(int ShippingMethod_Id, int Country_Id)
     {
        var shippingMethodRestrictions = _service.GetShippingMethodRestrictions(ShippingMethod_Id, Country_Id);
        if (shippingMethodRestrictions == null)
        {
          return NotFound();
        }
        return Ok(shippingMethodRestrictions);
     }

     // POST: api/ShippingMethodRestrictions
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertShippingMethodRestrictions(JsonConvert.DeserializeObject<ShippingMethodRestrictionsDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/shippingMethodRestrictions", result);
     }

     // PUT: api/ShippingMethodRestrictions/5
     [Route("{ShippingMethod_Id:int}/{Country_Id:int}")]
     public IHttpActionResult Put(int ShippingMethod_Id, int Country_Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateShippingMethodRestrictions(ShippingMethod_Id, Country_Id, JsonConvert.DeserializeObject<ShippingMethodRestrictionsDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/ShippingMethodRestrictions/5
    [Route("{ShippingMethod_Id:int}/{Country_Id:int}")]
    public IHttpActionResult Delete(int ShippingMethod_Id, int Country_Id)
    {
       var result = _service.DeleteShippingMethodRestrictions(ShippingMethod_Id, Country_Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
