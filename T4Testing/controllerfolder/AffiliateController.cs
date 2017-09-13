using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/affiliate")]
   public class AffiliateController : ApiController
   {
     IAffiliateDTOService _service;

     public AffiliateController(IAffiliateDTOService service)
     {
        this._service = service;
     }

     // GET: api/Affiliate
     [Route("")]
     public IEnumerable<AffiliateDTO> Get()
     {
        return _service.GetAllAffiliate();
     }

     // GET: api/Affiliate/5
     [Route("{Id:int}")]
     public IHttpActionResult GetAffiliate(int Id)
     {
        var affiliate = _service.GetAffiliate(Id);
        if (affiliate == null)
        {
          return NotFound();
        }
        return Ok(affiliate);
     }

     // POST: api/Affiliate
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertAffiliate(JsonConvert.DeserializeObject<AffiliateDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/affiliate", result);
     }

     // PUT: api/Affiliate/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateAffiliate(Id, JsonConvert.DeserializeObject<AffiliateDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Affiliate/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteAffiliate(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
