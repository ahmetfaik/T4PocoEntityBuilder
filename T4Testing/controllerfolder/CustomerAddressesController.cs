using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/customerAddresses")]
   public class CustomerAddressesController : ApiController
   {
     ICustomerAddressesDTOService _service;

     public CustomerAddressesController(ICustomerAddressesDTOService service)
     {
        this._service = service;
     }

     // GET: api/CustomerAddresses
     [Route("")]
     public IEnumerable<CustomerAddressesDTO> Get()
     {
        return _service.GetAllCustomerAddresses();
     }

     // GET: api/CustomerAddresses/5
     [Route("{Customer_Id:int}/{Address_Id:int}")]
     public IHttpActionResult GetCustomerAddresses(int Customer_Id, int Address_Id)
     {
        var customerAddresses = _service.GetCustomerAddresses(Customer_Id, Address_Id);
        if (customerAddresses == null)
        {
          return NotFound();
        }
        return Ok(customerAddresses);
     }

     // POST: api/CustomerAddresses
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertCustomerAddresses(JsonConvert.DeserializeObject<CustomerAddressesDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/customerAddresses", result);
     }

     // PUT: api/CustomerAddresses/5
     [Route("{Customer_Id:int}/{Address_Id:int}")]
     public IHttpActionResult Put(int Customer_Id, int Address_Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateCustomerAddresses(Customer_Id, Address_Id, JsonConvert.DeserializeObject<CustomerAddressesDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/CustomerAddresses/5
    [Route("{Customer_Id:int}/{Address_Id:int}")]
    public IHttpActionResult Delete(int Customer_Id, int Address_Id)
    {
       var result = _service.DeleteCustomerAddresses(Customer_Id, Address_Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
