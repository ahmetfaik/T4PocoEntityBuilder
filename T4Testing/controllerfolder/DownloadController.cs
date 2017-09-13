using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/download")]
   public class DownloadController : ApiController
   {
     IDownloadDTOService _service;

     public DownloadController(IDownloadDTOService service)
     {
        this._service = service;
     }

     // GET: api/Download
     [Route("")]
     public IEnumerable<DownloadDTO> Get()
     {
        return _service.GetAllDownload();
     }

     // GET: api/Download/5
     [Route("{Id:int}")]
     public IHttpActionResult GetDownload(int Id)
     {
        var download = _service.GetDownload(Id);
        if (download == null)
        {
          return NotFound();
        }
        return Ok(download);
     }

     // POST: api/Download
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertDownload(JsonConvert.DeserializeObject<DownloadDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/download", result);
     }

     // PUT: api/Download/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateDownload(Id, JsonConvert.DeserializeObject<DownloadDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Download/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteDownload(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
