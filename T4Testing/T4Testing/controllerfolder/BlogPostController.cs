using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/blogPost")]
   public class BlogPostController : ApiController
   {
     IBlogPostDTOService _service;

     public BlogPostController(IBlogPostDTOService service)
     {
        this._service = service;
     }

     // GET: api/BlogPost
     [Route("")]
     public IEnumerable<BlogPostDTO> Get()
     {
        return _service.GetAllBlogPost();
     }

     // GET: api/BlogPost/5
     [Route("{Id:int}")]
     public IHttpActionResult GetBlogPost(int Id)
     {
        var blogPost = _service.GetBlogPost(Id);
        if (blogPost == null)
        {
          return NotFound();
        }
        return Ok(blogPost);
     }

     // POST: api/BlogPost
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertBlogPost(JsonConvert.DeserializeObject<BlogPostDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/blogPost", result);
     }

     // PUT: api/BlogPost/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateBlogPost(Id, JsonConvert.DeserializeObject<BlogPostDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/BlogPost/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteBlogPost(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
