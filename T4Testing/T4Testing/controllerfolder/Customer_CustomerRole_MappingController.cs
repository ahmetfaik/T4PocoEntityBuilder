using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/customer_CustomerRole_Mapping")]
   public class Customer_CustomerRole_MappingController : ApiController
   {
     ICustomer_CustomerRole_MappingDTOService _service;

     public Customer_CustomerRole_MappingController(ICustomer_CustomerRole_MappingDTOService service)
     {
        this._service = service;
     }

     // GET: api/Customer_CustomerRole_Mapping
     [Route("")]
     public IEnumerable<Customer_CustomerRole_MappingDTO> Get()
     {
        return _service.GetAllCustomer_CustomerRole_Mapping();
     }

     // GET: api/Customer_CustomerRole_Mapping/5
     [Route("{Customer_Id:int}/{CustomerRole_Id:int}")]
     public IHttpActionResult GetCustomer_CustomerRole_Mapping(int Customer_Id, int CustomerRole_Id)
     {
        var customer_CustomerRole_Mapping = _service.GetCustomer_CustomerRole_Mapping(Customer_Id, CustomerRole_Id);
        if (customer_CustomerRole_Mapping == null)
        {
          return NotFound();
        }
        return Ok(customer_CustomerRole_Mapping);
     }

     // POST: api/Customer_CustomerRole_Mapping
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertCustomer_CustomerRole_Mapping(JsonConvert.DeserializeObject<Customer_CustomerRole_MappingDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/customer_CustomerRole_Mapping", result);
     }

     // PUT: api/Customer_CustomerRole_Mapping/5
     [Route("{Customer_Id:int}/{CustomerRole_Id:int}")]
     public IHttpActionResult Put(int Customer_Id, int CustomerRole_Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateCustomer_CustomerRole_Mapping(Customer_Id, CustomerRole_Id, JsonConvert.DeserializeObject<Customer_CustomerRole_MappingDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Customer_CustomerRole_Mapping/5
    [Route("{Customer_Id:int}/{CustomerRole_Id:int}")]
    public IHttpActionResult Delete(int Customer_Id, int CustomerRole_Id)
    {
       var result = _service.DeleteCustomer_CustomerRole_Mapping(Customer_Id, CustomerRole_Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
