using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/localizedProperty")]
   public class LocalizedPropertyController : ApiController
   {
     ILocalizedPropertyDTOService _service;

     public LocalizedPropertyController(ILocalizedPropertyDTOService service)
     {
        this._service = service;
     }

     // GET: api/LocalizedProperty
     [Route("")]
     public IEnumerable<LocalizedPropertyDTO> Get()
     {
        return _service.GetAllLocalizedProperty();
     }

     // GET: api/LocalizedProperty/5
     [Route("{Id:int}")]
     public IHttpActionResult GetLocalizedProperty(int Id)
     {
        var localizedProperty = _service.GetLocalizedProperty(Id);
        if (localizedProperty == null)
        {
          return NotFound();
        }
        return Ok(localizedProperty);
     }

     // POST: api/LocalizedProperty
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertLocalizedProperty(JsonConvert.DeserializeObject<LocalizedPropertyDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/localizedProperty", result);
     }

     // PUT: api/LocalizedProperty/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateLocalizedProperty(Id, JsonConvert.DeserializeObject<LocalizedPropertyDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/LocalizedProperty/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteLocalizedProperty(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
