using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/deliveryDate")]
   public class DeliveryDateController : ApiController
   {
     IDeliveryDateDTOService _service;

     public DeliveryDateController(IDeliveryDateDTOService service)
     {
        this._service = service;
     }

     // GET: api/DeliveryDate
     [Route("")]
     public IEnumerable<DeliveryDateDTO> Get()
     {
        return _service.GetAllDeliveryDate();
     }

     // GET: api/DeliveryDate/5
     [Route("{Id:int}")]
     public IHttpActionResult GetDeliveryDate(int Id)
     {
        var deliveryDate = _service.GetDeliveryDate(Id);
        if (deliveryDate == null)
        {
          return NotFound();
        }
        return Ok(deliveryDate);
     }

     // POST: api/DeliveryDate
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertDeliveryDate(JsonConvert.DeserializeObject<DeliveryDateDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/deliveryDate", result);
     }

     // PUT: api/DeliveryDate/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateDeliveryDate(Id, JsonConvert.DeserializeObject<DeliveryDateDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/DeliveryDate/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteDeliveryDate(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
