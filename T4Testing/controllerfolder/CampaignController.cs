using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/campaign")]
   public class CampaignController : ApiController
   {
     ICampaignDTOService _service;

     public CampaignController(ICampaignDTOService service)
     {
        this._service = service;
     }

     // GET: api/Campaign
     [Route("")]
     public IEnumerable<CampaignDTO> Get()
     {
        return _service.GetAllCampaign();
     }

     // GET: api/Campaign/5
     [Route("{Id:int}")]
     public IHttpActionResult GetCampaign(int Id)
     {
        var campaign = _service.GetCampaign(Id);
        if (campaign == null)
        {
          return NotFound();
        }
        return Ok(campaign);
     }

     // POST: api/Campaign
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertCampaign(JsonConvert.DeserializeObject<CampaignDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/campaign", result);
     }

     // PUT: api/Campaign/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateCampaign(Id, JsonConvert.DeserializeObject<CampaignDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Campaign/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteCampaign(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
