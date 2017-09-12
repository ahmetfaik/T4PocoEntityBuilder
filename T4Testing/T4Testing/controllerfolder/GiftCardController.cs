using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/giftCard")]
   public class GiftCardController : ApiController
   {
     IGiftCardDTOService _service;

     public GiftCardController(IGiftCardDTOService service)
     {
        this._service = service;
     }

     // GET: api/GiftCard
     [Route("")]
     public IEnumerable<GiftCardDTO> Get()
     {
        return _service.GetAllGiftCard();
     }

     // GET: api/GiftCard/5
     [Route("{Id:int}")]
     public IHttpActionResult GetGiftCard(int Id)
     {
        var giftCard = _service.GetGiftCard(Id);
        if (giftCard == null)
        {
          return NotFound();
        }
        return Ok(giftCard);
     }

     // POST: api/GiftCard
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertGiftCard(JsonConvert.DeserializeObject<GiftCardDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/giftCard", result);
     }

     // PUT: api/GiftCard/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateGiftCard(Id, JsonConvert.DeserializeObject<GiftCardDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/GiftCard/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteGiftCard(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
