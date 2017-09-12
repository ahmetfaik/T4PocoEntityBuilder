using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/shoppingCartItem")]
   public class ShoppingCartItemController : ApiController
   {
     IShoppingCartItemDTOService _service;

     public ShoppingCartItemController(IShoppingCartItemDTOService service)
     {
        this._service = service;
     }

     // GET: api/ShoppingCartItem
     [Route("")]
     public IEnumerable<ShoppingCartItemDTO> Get()
     {
        return _service.GetAllShoppingCartItem();
     }

     // GET: api/ShoppingCartItem/5
     [Route("{Id:int}")]
     public IHttpActionResult GetShoppingCartItem(int Id)
     {
        var shoppingCartItem = _service.GetShoppingCartItem(Id);
        if (shoppingCartItem == null)
        {
          return NotFound();
        }
        return Ok(shoppingCartItem);
     }

     // POST: api/ShoppingCartItem
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertShoppingCartItem(JsonConvert.DeserializeObject<ShoppingCartItemDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/shoppingCartItem", result);
     }

     // PUT: api/ShoppingCartItem/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateShoppingCartItem(Id, JsonConvert.DeserializeObject<ShoppingCartItemDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/ShoppingCartItem/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteShoppingCartItem(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
