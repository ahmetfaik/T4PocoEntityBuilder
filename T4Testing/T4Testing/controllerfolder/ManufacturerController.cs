using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/manufacturer")]
   public class ManufacturerController : ApiController
   {
     IManufacturerDTOService _service;

     public ManufacturerController(IManufacturerDTOService service)
     {
        this._service = service;
     }

     // GET: api/Manufacturer
     [Route("")]
     public IEnumerable<ManufacturerDTO> Get()
     {
        return _service.GetAllManufacturer();
     }

     // GET: api/Manufacturer/5
     [Route("{Id:int}")]
     public IHttpActionResult GetManufacturer(int Id)
     {
        var manufacturer = _service.GetManufacturer(Id);
        if (manufacturer == null)
        {
          return NotFound();
        }
        return Ok(manufacturer);
     }

     // POST: api/Manufacturer
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertManufacturer(JsonConvert.DeserializeObject<ManufacturerDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/manufacturer", result);
     }

     // PUT: api/Manufacturer/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateManufacturer(Id, JsonConvert.DeserializeObject<ManufacturerDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Manufacturer/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteManufacturer(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
