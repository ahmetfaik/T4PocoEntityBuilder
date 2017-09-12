using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/measureWeight")]
   public class MeasureWeightController : ApiController
   {
     IMeasureWeightDTOService _service;

     public MeasureWeightController(IMeasureWeightDTOService service)
     {
        this._service = service;
     }

     // GET: api/MeasureWeight
     [Route("")]
     public IEnumerable<MeasureWeightDTO> Get()
     {
        return _service.GetAllMeasureWeight();
     }

     // GET: api/MeasureWeight/5
     [Route("{Id:int}")]
     public IHttpActionResult GetMeasureWeight(int Id)
     {
        var measureWeight = _service.GetMeasureWeight(Id);
        if (measureWeight == null)
        {
          return NotFound();
        }
        return Ok(measureWeight);
     }

     // POST: api/MeasureWeight
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertMeasureWeight(JsonConvert.DeserializeObject<MeasureWeightDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/measureWeight", result);
     }

     // PUT: api/MeasureWeight/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateMeasureWeight(Id, JsonConvert.DeserializeObject<MeasureWeightDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/MeasureWeight/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteMeasureWeight(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
