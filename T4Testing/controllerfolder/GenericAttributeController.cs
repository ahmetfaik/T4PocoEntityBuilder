using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/genericAttribute")]
   public class GenericAttributeController : ApiController
   {
     IGenericAttributeDTOService _service;

     public GenericAttributeController(IGenericAttributeDTOService service)
     {
        this._service = service;
     }

     // GET: api/GenericAttribute
     [Route("")]
     public IEnumerable<GenericAttributeDTO> Get()
     {
        return _service.GetAllGenericAttribute();
     }

     // GET: api/GenericAttribute/5
     [Route("{Id:int}")]
     public IHttpActionResult GetGenericAttribute(int Id)
     {
        var genericAttribute = _service.GetGenericAttribute(Id);
        if (genericAttribute == null)
        {
          return NotFound();
        }
        return Ok(genericAttribute);
     }

     // POST: api/GenericAttribute
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertGenericAttribute(JsonConvert.DeserializeObject<GenericAttributeDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/genericAttribute", result);
     }

     // PUT: api/GenericAttribute/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateGenericAttribute(Id, JsonConvert.DeserializeObject<GenericAttributeDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/GenericAttribute/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteGenericAttribute(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
