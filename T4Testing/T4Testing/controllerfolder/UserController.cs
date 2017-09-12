using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/user")]
   public class UserController : ApiController
   {
     IUserDTOService _service;

     public UserController(IUserDTOService service)
     {
        this._service = service;
     }

     // GET: api/User
     [Route("")]
     public IEnumerable<UserDTO> Get()
     {
        return _service.GetAllUser();
     }

     // GET: api/User/5
     [Route("{Id:int}")]
     public IHttpActionResult GetUser(int Id)
     {
        var user = _service.GetUser(Id);
        if (user == null)
        {
          return NotFound();
        }
        return Ok(user);
     }

     // POST: api/User
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertUser(JsonConvert.DeserializeObject<UserDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/user", result);
     }

     // PUT: api/User/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateUser(Id, JsonConvert.DeserializeObject<UserDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/User/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteUser(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
