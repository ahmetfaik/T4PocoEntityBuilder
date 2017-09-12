using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/newsLetterSubscription")]
   public class NewsLetterSubscriptionController : ApiController
   {
     INewsLetterSubscriptionDTOService _service;

     public NewsLetterSubscriptionController(INewsLetterSubscriptionDTOService service)
     {
        this._service = service;
     }

     // GET: api/NewsLetterSubscription
     [Route("")]
     public IEnumerable<NewsLetterSubscriptionDTO> Get()
     {
        return _service.GetAllNewsLetterSubscription();
     }

     // GET: api/NewsLetterSubscription/5
     [Route("{Id:int}")]
     public IHttpActionResult GetNewsLetterSubscription(int Id)
     {
        var newsLetterSubscription = _service.GetNewsLetterSubscription(Id);
        if (newsLetterSubscription == null)
        {
          return NotFound();
        }
        return Ok(newsLetterSubscription);
     }

     // POST: api/NewsLetterSubscription
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertNewsLetterSubscription(JsonConvert.DeserializeObject<NewsLetterSubscriptionDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/newsLetterSubscription", result);
     }

     // PUT: api/NewsLetterSubscription/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateNewsLetterSubscription(Id, JsonConvert.DeserializeObject<NewsLetterSubscriptionDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/NewsLetterSubscription/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteNewsLetterSubscription(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
