using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/urlRecord")]
   public class UrlRecordController : ApiController
   {
     IUrlRecordDTOService _service;

     public UrlRecordController(IUrlRecordDTOService service)
     {
        this._service = service;
     }

     // GET: api/UrlRecord
     [Route("")]
     public IEnumerable<UrlRecordDTO> Get()
     {
        return _service.GetAllUrlRecord();
     }

     // GET: api/UrlRecord/5
     [Route("{Id:int}")]
     public IHttpActionResult GetUrlRecord(int Id)
     {
        var urlRecord = _service.GetUrlRecord(Id);
        if (urlRecord == null)
        {
          return NotFound();
        }
        return Ok(urlRecord);
     }

     // POST: api/UrlRecord
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertUrlRecord(JsonConvert.DeserializeObject<UrlRecordDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/urlRecord", result);
     }

     // PUT: api/UrlRecord/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateUrlRecord(Id, JsonConvert.DeserializeObject<UrlRecordDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/UrlRecord/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteUrlRecord(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
