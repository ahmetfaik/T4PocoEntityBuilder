using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/categoryTemplate")]
   public class CategoryTemplateController : ApiController
   {
     ICategoryTemplateDTOService _service;

     public CategoryTemplateController(ICategoryTemplateDTOService service)
     {
        this._service = service;
     }

     // GET: api/CategoryTemplate
     [Route("")]
     public IEnumerable<CategoryTemplateDTO> Get()
     {
        return _service.GetAllCategoryTemplate();
     }

     // GET: api/CategoryTemplate/5
     [Route("{Id:int}")]
     public IHttpActionResult GetCategoryTemplate(int Id)
     {
        var categoryTemplate = _service.GetCategoryTemplate(Id);
        if (categoryTemplate == null)
        {
          return NotFound();
        }
        return Ok(categoryTemplate);
     }

     // POST: api/CategoryTemplate
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertCategoryTemplate(JsonConvert.DeserializeObject<CategoryTemplateDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/categoryTemplate", result);
     }

     // PUT: api/CategoryTemplate/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateCategoryTemplate(Id, JsonConvert.DeserializeObject<CategoryTemplateDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/CategoryTemplate/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteCategoryTemplate(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
