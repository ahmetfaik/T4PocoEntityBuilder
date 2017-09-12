using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/returnRequestReason")]
   public class ReturnRequestReasonController : ApiController
   {
     IReturnRequestReasonDTOService _service;

     public ReturnRequestReasonController(IReturnRequestReasonDTOService service)
     {
        this._service = service;
     }

     // GET: api/ReturnRequestReason
     [Route("")]
     public IEnumerable<ReturnRequestReasonDTO> Get()
     {
        return _service.GetAllReturnRequestReason();
     }

     // GET: api/ReturnRequestReason/5
     [Route("{Id:int}")]
     public IHttpActionResult GetReturnRequestReason(int Id)
     {
        var returnRequestReason = _service.GetReturnRequestReason(Id);
        if (returnRequestReason == null)
        {
          return NotFound();
        }
        return Ok(returnRequestReason);
     }

     // POST: api/ReturnRequestReason
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertReturnRequestReason(JsonConvert.DeserializeObject<ReturnRequestReasonDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/returnRequestReason", result);
     }

     // PUT: api/ReturnRequestReason/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateReturnRequestReason(Id, JsonConvert.DeserializeObject<ReturnRequestReasonDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/ReturnRequestReason/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteReturnRequestReason(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
