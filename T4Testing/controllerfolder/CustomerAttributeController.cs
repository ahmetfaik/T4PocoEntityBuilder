using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/customerAttribute")]
   public class CustomerAttributeController : ApiController
   {
     ICustomerAttributeDTOService _service;

     public CustomerAttributeController(ICustomerAttributeDTOService service)
     {
        this._service = service;
     }

     // GET: api/CustomerAttribute
     [Route("")]
     public IEnumerable<CustomerAttributeDTO> Get()
     {
        return _service.GetAllCustomerAttribute();
     }

     // GET: api/CustomerAttribute/5
     [Route("{Id:int}")]
     public IHttpActionResult GetCustomerAttribute(int Id)
     {
        var customerAttribute = _service.GetCustomerAttribute(Id);
        if (customerAttribute == null)
        {
          return NotFound();
        }
        return Ok(customerAttribute);
     }

     // POST: api/CustomerAttribute
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertCustomerAttribute(JsonConvert.DeserializeObject<CustomerAttributeDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/customerAttribute", result);
     }

     // PUT: api/CustomerAttribute/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateCustomerAttribute(Id, JsonConvert.DeserializeObject<CustomerAttributeDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/CustomerAttribute/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteCustomerAttribute(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
