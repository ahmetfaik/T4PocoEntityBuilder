using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/customer")]
   public class CustomerController : ApiController
   {
     ICustomerDTOService _service;

     public CustomerController(ICustomerDTOService service)
     {
        this._service = service;
     }

     // GET: api/Customer
     [Route("")]
     public IEnumerable<CustomerDTO> Get()
     {
        return _service.GetAllCustomer();
     }

     // GET: api/Customer/5
     [Route("{Id:int}")]
     public IHttpActionResult GetCustomer(int Id)
     {
        var customer = _service.GetCustomer(Id);
        if (customer == null)
        {
          return NotFound();
        }
        return Ok(customer);
     }

     // POST: api/Customer
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertCustomer(JsonConvert.DeserializeObject<CustomerDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/customer", result);
     }

     // PUT: api/Customer/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateCustomer(Id, JsonConvert.DeserializeObject<CustomerDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Customer/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteCustomer(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
