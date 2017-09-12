using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/orderItem")]
   public class OrderItemController : ApiController
   {
     IOrderItemDTOService _service;

     public OrderItemController(IOrderItemDTOService service)
     {
        this._service = service;
     }

     // GET: api/OrderItem
     [Route("")]
     public IEnumerable<OrderItemDTO> Get()
     {
        return _service.GetAllOrderItem();
     }

     // GET: api/OrderItem/5
     [Route("{Id:int}")]
     public IHttpActionResult GetOrderItem(int Id)
     {
        var orderItem = _service.GetOrderItem(Id);
        if (orderItem == null)
        {
          return NotFound();
        }
        return Ok(orderItem);
     }

     // POST: api/OrderItem
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertOrderItem(JsonConvert.DeserializeObject<OrderItemDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/orderItem", result);
     }

     // PUT: api/OrderItem/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateOrderItem(Id, JsonConvert.DeserializeObject<OrderItemDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/OrderItem/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteOrderItem(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
