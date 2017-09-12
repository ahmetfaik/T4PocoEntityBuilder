using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/vendor")]
   public class VendorController : ApiController
   {
     IVendorDTOService _service;

     public VendorController(IVendorDTOService service)
     {
        this._service = service;
     }

     // GET: api/Vendor
     [Route("")]
     public IEnumerable<VendorDTO> Get()
     {
        return _service.GetAllVendor();
     }

     // GET: api/Vendor/5
     [Route("{Id:int}")]
     public IHttpActionResult GetVendor(int Id)
     {
        var vendor = _service.GetVendor(Id);
        if (vendor == null)
        {
          return NotFound();
        }
        return Ok(vendor);
     }

     // POST: api/Vendor
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertVendor(JsonConvert.DeserializeObject<VendorDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/vendor", result);
     }

     // PUT: api/Vendor/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateVendor(Id, JsonConvert.DeserializeObject<VendorDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Vendor/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteVendor(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
