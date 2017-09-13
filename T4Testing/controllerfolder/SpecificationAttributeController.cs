using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/specificationAttribute")]
   public class SpecificationAttributeController : ApiController
   {
     ISpecificationAttributeDTOService _service;

     public SpecificationAttributeController(ISpecificationAttributeDTOService service)
     {
        this._service = service;
     }

     // GET: api/SpecificationAttribute
     [Route("")]
     public IEnumerable<SpecificationAttributeDTO> Get()
     {
        return _service.GetAllSpecificationAttribute();
     }

     // GET: api/SpecificationAttribute/5
     [Route("{Id:int}")]
     public IHttpActionResult GetSpecificationAttribute(int Id)
     {
        var specificationAttribute = _service.GetSpecificationAttribute(Id);
        if (specificationAttribute == null)
        {
          return NotFound();
        }
        return Ok(specificationAttribute);
     }

     // POST: api/SpecificationAttribute
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertSpecificationAttribute(JsonConvert.DeserializeObject<SpecificationAttributeDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/specificationAttribute", result);
     }

     // PUT: api/SpecificationAttribute/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateSpecificationAttribute(Id, JsonConvert.DeserializeObject<SpecificationAttributeDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/SpecificationAttribute/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteSpecificationAttribute(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
