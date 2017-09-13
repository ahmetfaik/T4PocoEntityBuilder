using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/store")]
   public class StoreController : ApiController
   {
     IStoreDTOService _service;

     public StoreController(IStoreDTOService service)
     {
        this._service = service;
     }

     // GET: api/Store
     [Route("")]
     public IEnumerable<StoreDTO> Get()
     {
        return _service.GetAllStore();
     }

     // GET: api/Store/5
     [Route("{Id:int}")]
     public IHttpActionResult GetStore(int Id)
     {
        var store = _service.GetStore(Id);
        if (store == null)
        {
          return NotFound();
        }
        return Ok(store);
     }

     // POST: api/Store
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertStore(JsonConvert.DeserializeObject<StoreDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/store", result);
     }

     // PUT: api/Store/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateStore(Id, JsonConvert.DeserializeObject<StoreDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Store/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteStore(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
