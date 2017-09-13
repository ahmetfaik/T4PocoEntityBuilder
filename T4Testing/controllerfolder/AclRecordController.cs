using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/aclRecord")]
   public class AclRecordController : ApiController
   {
     IAclRecordDTOService _service;

     public AclRecordController(IAclRecordDTOService service)
     {
        this._service = service;
     }

     // GET: api/AclRecord
     [Route("")]
     public IEnumerable<AclRecordDTO> Get()
     {
        return _service.GetAllAclRecord();
     }

     // GET: api/AclRecord/5
     [Route("{Id:int}")]
     public IHttpActionResult GetAclRecord(int Id)
     {
        var aclRecord = _service.GetAclRecord(Id);
        if (aclRecord == null)
        {
          return NotFound();
        }
        return Ok(aclRecord);
     }

     // POST: api/AclRecord
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertAclRecord(JsonConvert.DeserializeObject<AclRecordDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/aclRecord", result);
     }

     // PUT: api/AclRecord/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateAclRecord(Id, JsonConvert.DeserializeObject<AclRecordDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/AclRecord/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteAclRecord(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
