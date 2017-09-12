using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/returnRequestAction")]
   public class ReturnRequestActionController : ApiController
   {
     IReturnRequestActionDTOService _service;

     public ReturnRequestActionController(IReturnRequestActionDTOService service)
     {
        this._service = service;
     }

     // GET: api/ReturnRequestAction
     [Route("")]
     public IEnumerable<ReturnRequestActionDTO> Get()
     {
        return _service.GetAllReturnRequestAction();
     }

     // GET: api/ReturnRequestAction/5
     [Route("{Id:int}")]
     public IHttpActionResult GetReturnRequestAction(int Id)
     {
        var returnRequestAction = _service.GetReturnRequestAction(Id);
        if (returnRequestAction == null)
        {
          return NotFound();
        }
        return Ok(returnRequestAction);
     }

     // POST: api/ReturnRequestAction
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertReturnRequestAction(JsonConvert.DeserializeObject<ReturnRequestActionDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/returnRequestAction", result);
     }

     // PUT: api/ReturnRequestAction/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateReturnRequestAction(Id, JsonConvert.DeserializeObject<ReturnRequestActionDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/ReturnRequestAction/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteReturnRequestAction(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
