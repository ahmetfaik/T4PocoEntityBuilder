using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/predefinedProductAttributeValue")]
   public class PredefinedProductAttributeValueController : ApiController
   {
     IPredefinedProductAttributeValueDTOService _service;

     public PredefinedProductAttributeValueController(IPredefinedProductAttributeValueDTOService service)
     {
        this._service = service;
     }

     // GET: api/PredefinedProductAttributeValue
     [Route("")]
     public IEnumerable<PredefinedProductAttributeValueDTO> Get()
     {
        return _service.GetAllPredefinedProductAttributeValue();
     }

     // GET: api/PredefinedProductAttributeValue/5
     [Route("{Id:int}")]
     public IHttpActionResult GetPredefinedProductAttributeValue(int Id)
     {
        var predefinedProductAttributeValue = _service.GetPredefinedProductAttributeValue(Id);
        if (predefinedProductAttributeValue == null)
        {
          return NotFound();
        }
        return Ok(predefinedProductAttributeValue);
     }

     // POST: api/PredefinedProductAttributeValue
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertPredefinedProductAttributeValue(JsonConvert.DeserializeObject<PredefinedProductAttributeValueDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/predefinedProductAttributeValue", result);
     }

     // PUT: api/PredefinedProductAttributeValue/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdatePredefinedProductAttributeValue(Id, JsonConvert.DeserializeObject<PredefinedProductAttributeValueDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/PredefinedProductAttributeValue/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeletePredefinedProductAttributeValue(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
