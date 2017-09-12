using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/orderNote")]
   public class OrderNoteController : ApiController
   {
     IOrderNoteDTOService _service;

     public OrderNoteController(IOrderNoteDTOService service)
     {
        this._service = service;
     }

     // GET: api/OrderNote
     [Route("")]
     public IEnumerable<OrderNoteDTO> Get()
     {
        return _service.GetAllOrderNote();
     }

     // GET: api/OrderNote/5
     [Route("{Id:int}")]
     public IHttpActionResult GetOrderNote(int Id)
     {
        var orderNote = _service.GetOrderNote(Id);
        if (orderNote == null)
        {
          return NotFound();
        }
        return Ok(orderNote);
     }

     // POST: api/OrderNote
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertOrderNote(JsonConvert.DeserializeObject<OrderNoteDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/orderNote", result);
     }

     // PUT: api/OrderNote/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateOrderNote(Id, JsonConvert.DeserializeObject<OrderNoteDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/OrderNote/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteOrderNote(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
