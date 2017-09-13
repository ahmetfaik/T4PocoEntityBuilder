using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/language")]
   public class LanguageController : ApiController
   {
     ILanguageDTOService _service;

     public LanguageController(ILanguageDTOService service)
     {
        this._service = service;
     }

     // GET: api/Language
     [Route("")]
     public IEnumerable<LanguageDTO> Get()
     {
        return _service.GetAllLanguage();
     }

     // GET: api/Language/5
     [Route("{Id:int}")]
     public IHttpActionResult GetLanguage(int Id)
     {
        var language = _service.GetLanguage(Id);
        if (language == null)
        {
          return NotFound();
        }
        return Ok(language);
     }

     // POST: api/Language
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertLanguage(JsonConvert.DeserializeObject<LanguageDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/language", result);
     }

     // PUT: api/Language/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateLanguage(Id, JsonConvert.DeserializeObject<LanguageDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Language/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteLanguage(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
