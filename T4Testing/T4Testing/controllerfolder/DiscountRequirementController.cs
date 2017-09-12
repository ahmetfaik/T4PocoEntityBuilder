using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/discountRequirement")]
   public class DiscountRequirementController : ApiController
   {
     IDiscountRequirementDTOService _service;

     public DiscountRequirementController(IDiscountRequirementDTOService service)
     {
        this._service = service;
     }

     // GET: api/DiscountRequirement
     [Route("")]
     public IEnumerable<DiscountRequirementDTO> Get()
     {
        return _service.GetAllDiscountRequirement();
     }

     // GET: api/DiscountRequirement/5
     [Route("{Id:int}")]
     public IHttpActionResult GetDiscountRequirement(int Id)
     {
        var discountRequirement = _service.GetDiscountRequirement(Id);
        if (discountRequirement == null)
        {
          return NotFound();
        }
        return Ok(discountRequirement);
     }

     // POST: api/DiscountRequirement
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertDiscountRequirement(JsonConvert.DeserializeObject<DiscountRequirementDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/discountRequirement", result);
     }

     // PUT: api/DiscountRequirement/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateDiscountRequirement(Id, JsonConvert.DeserializeObject<DiscountRequirementDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/DiscountRequirement/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteDiscountRequirement(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
