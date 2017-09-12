using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/shipment")]
   public class ShipmentController : ApiController
   {
     IShipmentDTOService _service;

     public ShipmentController(IShipmentDTOService service)
     {
        this._service = service;
     }

     // GET: api/Shipment
     [Route("")]
     public IEnumerable<ShipmentDTO> Get()
     {
        return _service.GetAllShipment();
     }

     // GET: api/Shipment/5
     [Route("{Id:int}")]
     public IHttpActionResult GetShipment(int Id)
     {
        var shipment = _service.GetShipment(Id);
        if (shipment == null)
        {
          return NotFound();
        }
        return Ok(shipment);
     }

     // POST: api/Shipment
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertShipment(JsonConvert.DeserializeObject<ShipmentDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/shipment", result);
     }

     // PUT: api/Shipment/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateShipment(Id, JsonConvert.DeserializeObject<ShipmentDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Shipment/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteShipment(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
