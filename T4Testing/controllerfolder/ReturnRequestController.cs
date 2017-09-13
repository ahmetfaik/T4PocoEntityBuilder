using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/returnRequest")]
   public class ReturnRequestController : ApiController
   {
     IReturnRequestDTOService _service;

     public ReturnRequestController(IReturnRequestDTOService service)
     {
        this._service = service;
     }

     // GET: api/ReturnRequest
     [Route("")]
     public IEnumerable<ReturnRequestDTO> Get()
     {
        return _service.GetAllReturnRequest();
     }

     // GET: api/ReturnRequest/5
     [Route("{Id:int}")]
     public IHttpActionResult GetReturnRequest(int Id)
     {
        var returnRequest = _service.GetReturnRequest(Id);
        if (returnRequest == null)
        {
          return NotFound();
        }
        return Ok(returnRequest);
     }

     // POST: api/ReturnRequest
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertReturnRequest(JsonConvert.DeserializeObject<ReturnRequestDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/returnRequest", result);
     }

     // PUT: api/ReturnRequest/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateReturnRequest(Id, JsonConvert.DeserializeObject<ReturnRequestDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/ReturnRequest/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteReturnRequest(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
