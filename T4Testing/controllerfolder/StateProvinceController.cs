using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/stateProvince")]
   public class StateProvinceController : ApiController
   {
     IStateProvinceDTOService _service;

     public StateProvinceController(IStateProvinceDTOService service)
     {
        this._service = service;
     }

     // GET: api/StateProvince
     [Route("")]
     public IEnumerable<StateProvinceDTO> Get()
     {
        return _service.GetAllStateProvince();
     }

     // GET: api/StateProvince/5
     [Route("{Id:int}")]
     public IHttpActionResult GetStateProvince(int Id)
     {
        var stateProvince = _service.GetStateProvince(Id);
        if (stateProvince == null)
        {
          return NotFound();
        }
        return Ok(stateProvince);
     }

     // POST: api/StateProvince
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertStateProvince(JsonConvert.DeserializeObject<StateProvinceDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/stateProvince", result);
     }

     // PUT: api/StateProvince/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateStateProvince(Id, JsonConvert.DeserializeObject<StateProvinceDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/StateProvince/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteStateProvince(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
