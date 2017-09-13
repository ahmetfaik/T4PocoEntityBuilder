using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/order")]
   public class OrderController : ApiController
   {
     IOrderDTOService _service;

     public OrderController(IOrderDTOService service)
     {
        this._service = service;
     }

     // GET: api/Order
     [Route("")]
     public IEnumerable<OrderDTO> Get()
     {
        return _service.GetAllOrder();
     }

     // GET: api/Order/5
     [Route("{Id:int}")]
     public IHttpActionResult GetOrder(int Id)
     {
        var order = _service.GetOrder(Id);
        if (order == null)
        {
          return NotFound();
        }
        return Ok(order);
     }

     // POST: api/Order
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertOrder(JsonConvert.DeserializeObject<OrderDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/order", result);
     }

     // PUT: api/Order/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateOrder(Id, JsonConvert.DeserializeObject<OrderDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Order/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteOrder(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
