using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/specificationAttributeOption")]
   public class SpecificationAttributeOptionController : ApiController
   {
     ISpecificationAttributeOptionDTOService _service;

     public SpecificationAttributeOptionController(ISpecificationAttributeOptionDTOService service)
     {
        this._service = service;
     }

     // GET: api/SpecificationAttributeOption
     [Route("")]
     public IEnumerable<SpecificationAttributeOptionDTO> Get()
     {
        return _service.GetAllSpecificationAttributeOption();
     }

     // GET: api/SpecificationAttributeOption/5
     [Route("{Id:int}")]
     public IHttpActionResult GetSpecificationAttributeOption(int Id)
     {
        var specificationAttributeOption = _service.GetSpecificationAttributeOption(Id);
        if (specificationAttributeOption == null)
        {
          return NotFound();
        }
        return Ok(specificationAttributeOption);
     }

     // POST: api/SpecificationAttributeOption
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertSpecificationAttributeOption(JsonConvert.DeserializeObject<SpecificationAttributeOptionDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/specificationAttributeOption", result);
     }

     // PUT: api/SpecificationAttributeOption/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateSpecificationAttributeOption(Id, JsonConvert.DeserializeObject<SpecificationAttributeOptionDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/SpecificationAttributeOption/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteSpecificationAttributeOption(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
