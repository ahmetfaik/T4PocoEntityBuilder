using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/productTemplate")]
   public class ProductTemplateController : ApiController
   {
     IProductTemplateDTOService _service;

     public ProductTemplateController(IProductTemplateDTOService service)
     {
        this._service = service;
     }

     // GET: api/ProductTemplate
     [Route("")]
     public IEnumerable<ProductTemplateDTO> Get()
     {
        return _service.GetAllProductTemplate();
     }

     // GET: api/ProductTemplate/5
     [Route("{Id:int}")]
     public IHttpActionResult GetProductTemplate(int Id)
     {
        var productTemplate = _service.GetProductTemplate(Id);
        if (productTemplate == null)
        {
          return NotFound();
        }
        return Ok(productTemplate);
     }

     // POST: api/ProductTemplate
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertProductTemplate(JsonConvert.DeserializeObject<ProductTemplateDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/productTemplate", result);
     }

     // PUT: api/ProductTemplate/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateProductTemplate(Id, JsonConvert.DeserializeObject<ProductTemplateDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/ProductTemplate/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteProductTemplate(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
