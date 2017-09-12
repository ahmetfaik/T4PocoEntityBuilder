using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/addressAttribute")]
   public class AddressAttributeController : ApiController
   {
     IAddressAttributeDTOService _service;

     public AddressAttributeController(IAddressAttributeDTOService service)
     {
        this._service = service;
     }

     // GET: api/AddressAttribute
     [Route("")]
     public IEnumerable<AddressAttributeDTO> Get()
     {
        return _service.GetAllAddressAttribute();
     }

     // GET: api/AddressAttribute/5
     [Route("{Id:int}")]
     public IHttpActionResult GetAddressAttribute(int Id)
     {
        var addressAttribute = _service.GetAddressAttribute(Id);
        if (addressAttribute == null)
        {
          return NotFound();
        }
        return Ok(addressAttribute);
     }

     // POST: api/AddressAttribute
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertAddressAttribute(JsonConvert.DeserializeObject<AddressAttributeDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/addressAttribute", result);
     }

     // PUT: api/AddressAttribute/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateAddressAttribute(Id, JsonConvert.DeserializeObject<AddressAttributeDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/AddressAttribute/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteAddressAttribute(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
