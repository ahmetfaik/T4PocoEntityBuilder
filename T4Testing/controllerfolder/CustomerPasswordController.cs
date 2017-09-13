using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/customerPassword")]
   public class CustomerPasswordController : ApiController
   {
     ICustomerPasswordDTOService _service;

     public CustomerPasswordController(ICustomerPasswordDTOService service)
     {
        this._service = service;
     }

     // GET: api/CustomerPassword
     [Route("")]
     public IEnumerable<CustomerPasswordDTO> Get()
     {
        return _service.GetAllCustomerPassword();
     }

     // GET: api/CustomerPassword/5
     [Route("{Id:int}")]
     public IHttpActionResult GetCustomerPassword(int Id)
     {
        var customerPassword = _service.GetCustomerPassword(Id);
        if (customerPassword == null)
        {
          return NotFound();
        }
        return Ok(customerPassword);
     }

     // POST: api/CustomerPassword
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertCustomerPassword(JsonConvert.DeserializeObject<CustomerPasswordDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/customerPassword", result);
     }

     // PUT: api/CustomerPassword/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateCustomerPassword(Id, JsonConvert.DeserializeObject<CustomerPasswordDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/CustomerPassword/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteCustomerPassword(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
