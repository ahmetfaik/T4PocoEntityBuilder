using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/blogComment")]
   public class BlogCommentController : ApiController
   {
     IBlogCommentDTOService _service;

     public BlogCommentController(IBlogCommentDTOService service)
     {
        this._service = service;
     }

     // GET: api/BlogComment
     [Route("")]
     public IEnumerable<BlogCommentDTO> Get()
     {
        return _service.GetAllBlogComment();
     }

     // GET: api/BlogComment/5
     [Route("{Id:int}")]
     public IHttpActionResult GetBlogComment(int Id)
     {
        var blogComment = _service.GetBlogComment(Id);
        if (blogComment == null)
        {
          return NotFound();
        }
        return Ok(blogComment);
     }

     // POST: api/BlogComment
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertBlogComment(JsonConvert.DeserializeObject<BlogCommentDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/blogComment", result);
     }

     // PUT: api/BlogComment/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateBlogComment(Id, JsonConvert.DeserializeObject<BlogCommentDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/BlogComment/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteBlogComment(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
