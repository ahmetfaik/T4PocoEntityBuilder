using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/manufacturerTemplate")]
   public class ManufacturerTemplateController : ApiController
   {
     IManufacturerTemplateDTOService _service;

     public ManufacturerTemplateController(IManufacturerTemplateDTOService service)
     {
        this._service = service;
     }

     // GET: api/ManufacturerTemplate
     [Route("")]
     public IEnumerable<ManufacturerTemplateDTO> Get()
     {
        return _service.GetAllManufacturerTemplate();
     }

     // GET: api/ManufacturerTemplate/5
     [Route("{Id:int}")]
     public IHttpActionResult GetManufacturerTemplate(int Id)
     {
        var manufacturerTemplate = _service.GetManufacturerTemplate(Id);
        if (manufacturerTemplate == null)
        {
          return NotFound();
        }
        return Ok(manufacturerTemplate);
     }

     // POST: api/ManufacturerTemplate
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertManufacturerTemplate(JsonConvert.DeserializeObject<ManufacturerTemplateDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/manufacturerTemplate", result);
     }

     // PUT: api/ManufacturerTemplate/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateManufacturerTemplate(Id, JsonConvert.DeserializeObject<ManufacturerTemplateDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/ManufacturerTemplate/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteManufacturerTemplate(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
