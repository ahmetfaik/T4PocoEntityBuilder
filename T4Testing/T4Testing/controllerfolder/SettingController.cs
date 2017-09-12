using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/setting")]
   public class SettingController : ApiController
   {
     ISettingDTOService _service;

     public SettingController(ISettingDTOService service)
     {
        this._service = service;
     }

     // GET: api/Setting
     [Route("")]
     public IEnumerable<SettingDTO> Get()
     {
        return _service.GetAllSetting();
     }

     // GET: api/Setting/5
     [Route("{Id:int}")]
     public IHttpActionResult GetSetting(int Id)
     {
        var setting = _service.GetSetting(Id);
        if (setting == null)
        {
          return NotFound();
        }
        return Ok(setting);
     }

     // POST: api/Setting
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertSetting(JsonConvert.DeserializeObject<SettingDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/setting", result);
     }

     // PUT: api/Setting/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateSetting(Id, JsonConvert.DeserializeObject<SettingDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Setting/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteSetting(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
