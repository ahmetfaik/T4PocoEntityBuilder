using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/permissionRecord")]
   public class PermissionRecordController : ApiController
   {
     IPermissionRecordDTOService _service;

     public PermissionRecordController(IPermissionRecordDTOService service)
     {
        this._service = service;
     }

     // GET: api/PermissionRecord
     [Route("")]
     public IEnumerable<PermissionRecordDTO> Get()
     {
        return _service.GetAllPermissionRecord();
     }

     // GET: api/PermissionRecord/5
     [Route("{Id:int}")]
     public IHttpActionResult GetPermissionRecord(int Id)
     {
        var permissionRecord = _service.GetPermissionRecord(Id);
        if (permissionRecord == null)
        {
          return NotFound();
        }
        return Ok(permissionRecord);
     }

     // POST: api/PermissionRecord
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertPermissionRecord(JsonConvert.DeserializeObject<PermissionRecordDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/permissionRecord", result);
     }

     // PUT: api/PermissionRecord/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdatePermissionRecord(Id, JsonConvert.DeserializeObject<PermissionRecordDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/PermissionRecord/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeletePermissionRecord(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
