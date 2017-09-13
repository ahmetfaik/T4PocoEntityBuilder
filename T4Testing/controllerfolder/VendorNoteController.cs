using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/vendorNote")]
   public class VendorNoteController : ApiController
   {
     IVendorNoteDTOService _service;

     public VendorNoteController(IVendorNoteDTOService service)
     {
        this._service = service;
     }

     // GET: api/VendorNote
     [Route("")]
     public IEnumerable<VendorNoteDTO> Get()
     {
        return _service.GetAllVendorNote();
     }

     // GET: api/VendorNote/5
     [Route("{Id:int}")]
     public IHttpActionResult GetVendorNote(int Id)
     {
        var vendorNote = _service.GetVendorNote(Id);
        if (vendorNote == null)
        {
          return NotFound();
        }
        return Ok(vendorNote);
     }

     // POST: api/VendorNote
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertVendorNote(JsonConvert.DeserializeObject<VendorNoteDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/vendorNote", result);
     }

     // PUT: api/VendorNote/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateVendorNote(Id, JsonConvert.DeserializeObject<VendorNoteDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/VendorNote/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteVendorNote(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
