using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/category")]
   public class CategoryController : ApiController
   {
     ICategoryDTOService _service;

     public CategoryController(ICategoryDTOService service)
     {
        this._service = service;
     }

     // GET: api/Category
     [Route("")]
     public IEnumerable<CategoryDTO> Get()
     {
        return _service.GetAllCategory();
     }

     // GET: api/Category/5
     [Route("{Id:int}")]
     public IHttpActionResult GetCategory(int Id)
     {
        var category = _service.GetCategory(Id);
        if (category == null)
        {
          return NotFound();
        }
        return Ok(category);
     }

     // POST: api/Category
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertCategory(JsonConvert.DeserializeObject<CategoryDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/category", result);
     }

     // PUT: api/Category/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateCategory(Id, JsonConvert.DeserializeObject<CategoryDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Category/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteCategory(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
