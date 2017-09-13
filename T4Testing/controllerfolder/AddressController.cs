using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/address")]
   public class AddressController : ApiController
   {
     IAddressDTOService _service;

     public AddressController(IAddressDTOService service)
     {
        this._service = service;
     }

     // GET: api/Address
     [Route("")]
     public IEnumerable<AddressDTO> Get()
     {
        return _service.GetAllAddress();
     }

     // GET: api/Address/5
     [Route("{Id:int}")]
     public IHttpActionResult GetAddress(int Id)
     {
        var address = _service.GetAddress(Id);
        if (address == null)
        {
          return NotFound();
        }
        return Ok(address);
     }

     // POST: api/Address
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertAddress(JsonConvert.DeserializeObject<AddressDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/address", result);
     }

     // PUT: api/Address/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateAddress(Id, JsonConvert.DeserializeObject<AddressDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Address/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteAddress(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
