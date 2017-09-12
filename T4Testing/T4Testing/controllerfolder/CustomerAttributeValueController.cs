using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/customerAttributeValue")]
   public class CustomerAttributeValueController : ApiController
   {
     ICustomerAttributeValueDTOService _service;

     public CustomerAttributeValueController(ICustomerAttributeValueDTOService service)
     {
        this._service = service;
     }

     // GET: api/CustomerAttributeValue
     [Route("")]
     public IEnumerable<CustomerAttributeValueDTO> Get()
     {
        return _service.GetAllCustomerAttributeValue();
     }

     // GET: api/CustomerAttributeValue/5
     [Route("{Id:int}")]
     public IHttpActionResult GetCustomerAttributeValue(int Id)
     {
        var customerAttributeValue = _service.GetCustomerAttributeValue(Id);
        if (customerAttributeValue == null)
        {
          return NotFound();
        }
        return Ok(customerAttributeValue);
     }

     // POST: api/CustomerAttributeValue
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertCustomerAttributeValue(JsonConvert.DeserializeObject<CustomerAttributeValueDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/customerAttributeValue", result);
     }

     // PUT: api/CustomerAttributeValue/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateCustomerAttributeValue(Id, JsonConvert.DeserializeObject<CustomerAttributeValueDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/CustomerAttributeValue/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteCustomerAttributeValue(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
