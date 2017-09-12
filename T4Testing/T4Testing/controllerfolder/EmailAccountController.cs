using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/emailAccount")]
   public class EmailAccountController : ApiController
   {
     IEmailAccountDTOService _service;

     public EmailAccountController(IEmailAccountDTOService service)
     {
        this._service = service;
     }

     // GET: api/EmailAccount
     [Route("")]
     public IEnumerable<EmailAccountDTO> Get()
     {
        return _service.GetAllEmailAccount();
     }

     // GET: api/EmailAccount/5
     [Route("{Id:int}")]
     public IHttpActionResult GetEmailAccount(int Id)
     {
        var emailAccount = _service.GetEmailAccount(Id);
        if (emailAccount == null)
        {
          return NotFound();
        }
        return Ok(emailAccount);
     }

     // POST: api/EmailAccount
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertEmailAccount(JsonConvert.DeserializeObject<EmailAccountDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/emailAccount", result);
     }

     // PUT: api/EmailAccount/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateEmailAccount(Id, JsonConvert.DeserializeObject<EmailAccountDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/EmailAccount/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteEmailAccount(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
