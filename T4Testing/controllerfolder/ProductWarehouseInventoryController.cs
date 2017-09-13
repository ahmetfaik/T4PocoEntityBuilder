using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/productWarehouseInventory")]
   public class ProductWarehouseInventoryController : ApiController
   {
     IProductWarehouseInventoryDTOService _service;

     public ProductWarehouseInventoryController(IProductWarehouseInventoryDTOService service)
     {
        this._service = service;
     }

     // GET: api/ProductWarehouseInventory
     [Route("")]
     public IEnumerable<ProductWarehouseInventoryDTO> Get()
     {
        return _service.GetAllProductWarehouseInventory();
     }

     // GET: api/ProductWarehouseInventory/5
     [Route("{Id:int}")]
     public IHttpActionResult GetProductWarehouseInventory(int Id)
     {
        var productWarehouseInventory = _service.GetProductWarehouseInventory(Id);
        if (productWarehouseInventory == null)
        {
          return NotFound();
        }
        return Ok(productWarehouseInventory);
     }

     // POST: api/ProductWarehouseInventory
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertProductWarehouseInventory(JsonConvert.DeserializeObject<ProductWarehouseInventoryDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/productWarehouseInventory", result);
     }

     // PUT: api/ProductWarehouseInventory/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateProductWarehouseInventory(Id, JsonConvert.DeserializeObject<ProductWarehouseInventoryDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/ProductWarehouseInventory/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteProductWarehouseInventory(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
