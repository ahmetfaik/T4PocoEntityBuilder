using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/news")]
   public class NewsController : ApiController
   {
     INewsDTOService _service;

     public NewsController(INewsDTOService service)
     {
        this._service = service;
     }

     // GET: api/News
     [Route("")]
     public IEnumerable<NewsDTO> Get()
     {
        return _service.GetAllNews();
     }

     // GET: api/News/5
     [Route("{Id:int}")]
     public IHttpActionResult GetNews(int Id)
     {
        var news = _service.GetNews(Id);
        if (news == null)
        {
          return NotFound();
        }
        return Ok(news);
     }

     // POST: api/News
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertNews(JsonConvert.DeserializeObject<NewsDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/news", result);
     }

     // PUT: api/News/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateNews(Id, JsonConvert.DeserializeObject<NewsDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/News/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteNews(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
