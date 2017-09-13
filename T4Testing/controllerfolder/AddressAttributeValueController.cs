using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/addressAttributeValue")]
   public class AddressAttributeValueController : ApiController
   {
     IAddressAttributeValueDTOService _service;

     public AddressAttributeValueController(IAddressAttributeValueDTOService service)
     {
        this._service = service;
     }

     // GET: api/AddressAttributeValue
     [Route("")]
     public IEnumerable<AddressAttributeValueDTO> Get()
     {
        return _service.GetAllAddressAttributeValue();
     }

     // GET: api/AddressAttributeValue/5
     [Route("{Id:int}")]
     public IHttpActionResult GetAddressAttributeValue(int Id)
     {
        var addressAttributeValue = _service.GetAddressAttributeValue(Id);
        if (addressAttributeValue == null)
        {
          return NotFound();
        }
        return Ok(addressAttributeValue);
     }

     // POST: api/AddressAttributeValue
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertAddressAttributeValue(JsonConvert.DeserializeObject<AddressAttributeValueDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/addressAttributeValue", result);
     }

     // PUT: api/AddressAttributeValue/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateAddressAttributeValue(Id, JsonConvert.DeserializeObject<AddressAttributeValueDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/AddressAttributeValue/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteAddressAttributeValue(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
