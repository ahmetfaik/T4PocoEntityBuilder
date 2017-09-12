using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/storeMapping")]
   public class StoreMappingController : ApiController
   {
     IStoreMappingDTOService _service;

     public StoreMappingController(IStoreMappingDTOService service)
     {
        this._service = service;
     }

     // GET: api/StoreMapping
     [Route("")]
     public IEnumerable<StoreMappingDTO> Get()
     {
        return _service.GetAllStoreMapping();
     }

     // GET: api/StoreMapping/5
     [Route("{Id:int}")]
     public IHttpActionResult GetStoreMapping(int Id)
     {
        var storeMapping = _service.GetStoreMapping(Id);
        if (storeMapping == null)
        {
          return NotFound();
        }
        return Ok(storeMapping);
     }

     // POST: api/StoreMapping
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertStoreMapping(JsonConvert.DeserializeObject<StoreMappingDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/storeMapping", result);
     }

     // PUT: api/StoreMapping/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateStoreMapping(Id, JsonConvert.DeserializeObject<StoreMappingDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/StoreMapping/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteStoreMapping(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
