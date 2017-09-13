using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/localeStringResource")]
   public class LocaleStringResourceController : ApiController
   {
     ILocaleStringResourceDTOService _service;

     public LocaleStringResourceController(ILocaleStringResourceDTOService service)
     {
        this._service = service;
     }

     // GET: api/LocaleStringResource
     [Route("")]
     public IEnumerable<LocaleStringResourceDTO> Get()
     {
        return _service.GetAllLocaleStringResource();
     }

     // GET: api/LocaleStringResource/5
     [Route("{Id:int}")]
     public IHttpActionResult GetLocaleStringResource(int Id)
     {
        var localeStringResource = _service.GetLocaleStringResource(Id);
        if (localeStringResource == null)
        {
          return NotFound();
        }
        return Ok(localeStringResource);
     }

     // POST: api/LocaleStringResource
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertLocaleStringResource(JsonConvert.DeserializeObject<LocaleStringResourceDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/localeStringResource", result);
     }

     // PUT: api/LocaleStringResource/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateLocaleStringResource(Id, JsonConvert.DeserializeObject<LocaleStringResourceDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/LocaleStringResource/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteLocaleStringResource(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
