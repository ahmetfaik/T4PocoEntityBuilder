using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/newsComment")]
   public class NewsCommentController : ApiController
   {
     INewsCommentDTOService _service;

     public NewsCommentController(INewsCommentDTOService service)
     {
        this._service = service;
     }

     // GET: api/NewsComment
     [Route("")]
     public IEnumerable<NewsCommentDTO> Get()
     {
        return _service.GetAllNewsComment();
     }

     // GET: api/NewsComment/5
     [Route("{Id:int}")]
     public IHttpActionResult GetNewsComment(int Id)
     {
        var newsComment = _service.GetNewsComment(Id);
        if (newsComment == null)
        {
          return NotFound();
        }
        return Ok(newsComment);
     }

     // POST: api/NewsComment
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertNewsComment(JsonConvert.DeserializeObject<NewsCommentDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/newsComment", result);
     }

     // PUT: api/NewsComment/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateNewsComment(Id, JsonConvert.DeserializeObject<NewsCommentDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/NewsComment/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteNewsComment(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
