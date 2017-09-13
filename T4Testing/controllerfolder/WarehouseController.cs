using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/warehouse")]
   public class WarehouseController : ApiController
   {
     IWarehouseDTOService _service;

     public WarehouseController(IWarehouseDTOService service)
     {
        this._service = service;
     }

     // GET: api/Warehouse
     [Route("")]
     public IEnumerable<WarehouseDTO> Get()
     {
        return _service.GetAllWarehouse();
     }

     // GET: api/Warehouse/5
     [Route("{Id:int}")]
     public IHttpActionResult GetWarehouse(int Id)
     {
        var warehouse = _service.GetWarehouse(Id);
        if (warehouse == null)
        {
          return NotFound();
        }
        return Ok(warehouse);
     }

     // POST: api/Warehouse
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertWarehouse(JsonConvert.DeserializeObject<WarehouseDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/warehouse", result);
     }

     // PUT: api/Warehouse/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateWarehouse(Id, JsonConvert.DeserializeObject<WarehouseDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Warehouse/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteWarehouse(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
