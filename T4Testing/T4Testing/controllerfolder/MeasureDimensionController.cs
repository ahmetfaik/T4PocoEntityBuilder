using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/measureDimension")]
   public class MeasureDimensionController : ApiController
   {
     IMeasureDimensionDTOService _service;

     public MeasureDimensionController(IMeasureDimensionDTOService service)
     {
        this._service = service;
     }

     // GET: api/MeasureDimension
     [Route("")]
     public IEnumerable<MeasureDimensionDTO> Get()
     {
        return _service.GetAllMeasureDimension();
     }

     // GET: api/MeasureDimension/5
     [Route("{Id:int}")]
     public IHttpActionResult GetMeasureDimension(int Id)
     {
        var measureDimension = _service.GetMeasureDimension(Id);
        if (measureDimension == null)
        {
          return NotFound();
        }
        return Ok(measureDimension);
     }

     // POST: api/MeasureDimension
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertMeasureDimension(JsonConvert.DeserializeObject<MeasureDimensionDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/measureDimension", result);
     }

     // PUT: api/MeasureDimension/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateMeasureDimension(Id, JsonConvert.DeserializeObject<MeasureDimensionDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/MeasureDimension/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteMeasureDimension(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
