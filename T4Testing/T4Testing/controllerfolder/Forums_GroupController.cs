using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/forums_Group")]
   public class Forums_GroupController : ApiController
   {
     IForums_GroupDTOService _service;

     public Forums_GroupController(IForums_GroupDTOService service)
     {
        this._service = service;
     }

     // GET: api/Forums_Group
     [Route("")]
     public IEnumerable<Forums_GroupDTO> Get()
     {
        return _service.GetAllForums_Group();
     }

     // GET: api/Forums_Group/5
     [Route("{Id:int}")]
     public IHttpActionResult GetForums_Group(int Id)
     {
        var forums_Group = _service.GetForums_Group(Id);
        if (forums_Group == null)
        {
          return NotFound();
        }
        return Ok(forums_Group);
     }

     // POST: api/Forums_Group
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertForums_Group(JsonConvert.DeserializeObject<Forums_GroupDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/forums_Group", result);
     }

     // PUT: api/Forums_Group/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateForums_Group(Id, JsonConvert.DeserializeObject<Forums_GroupDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Forums_Group/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteForums_Group(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
