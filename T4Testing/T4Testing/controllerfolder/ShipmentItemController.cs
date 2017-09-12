using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/shipmentItem")]
   public class ShipmentItemController : ApiController
   {
     IShipmentItemDTOService _service;

     public ShipmentItemController(IShipmentItemDTOService service)
     {
        this._service = service;
     }

     // GET: api/ShipmentItem
     [Route("")]
     public IEnumerable<ShipmentItemDTO> Get()
     {
        return _service.GetAllShipmentItem();
     }

     // GET: api/ShipmentItem/5
     [Route("{Id:int}")]
     public IHttpActionResult GetShipmentItem(int Id)
     {
        var shipmentItem = _service.GetShipmentItem(Id);
        if (shipmentItem == null)
        {
          return NotFound();
        }
        return Ok(shipmentItem);
     }

     // POST: api/ShipmentItem
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertShipmentItem(JsonConvert.DeserializeObject<ShipmentItemDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/shipmentItem", result);
     }

     // PUT: api/ShipmentItem/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateShipmentItem(Id, JsonConvert.DeserializeObject<ShipmentItemDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/ShipmentItem/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteShipmentItem(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
