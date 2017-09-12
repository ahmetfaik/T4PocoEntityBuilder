using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/customerRole")]
   public class CustomerRoleController : ApiController
   {
     ICustomerRoleDTOService _service;

     public CustomerRoleController(ICustomerRoleDTOService service)
     {
        this._service = service;
     }

     // GET: api/CustomerRole
     [Route("")]
     public IEnumerable<CustomerRoleDTO> Get()
     {
        return _service.GetAllCustomerRole();
     }

     // GET: api/CustomerRole/5
     [Route("{Id:int}")]
     public IHttpActionResult GetCustomerRole(int Id)
     {
        var customerRole = _service.GetCustomerRole(Id);
        if (customerRole == null)
        {
          return NotFound();
        }
        return Ok(customerRole);
     }

     // POST: api/CustomerRole
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertCustomerRole(JsonConvert.DeserializeObject<CustomerRoleDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/customerRole", result);
     }

     // PUT: api/CustomerRole/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateCustomerRole(Id, JsonConvert.DeserializeObject<CustomerRoleDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/CustomerRole/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteCustomerRole(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
