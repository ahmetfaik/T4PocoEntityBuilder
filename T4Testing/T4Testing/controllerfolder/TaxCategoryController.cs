using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/taxCategory")]
   public class TaxCategoryController : ApiController
   {
     ITaxCategoryDTOService _service;

     public TaxCategoryController(ITaxCategoryDTOService service)
     {
        this._service = service;
     }

     // GET: api/TaxCategory
     [Route("")]
     public IEnumerable<TaxCategoryDTO> Get()
     {
        return _service.GetAllTaxCategory();
     }

     // GET: api/TaxCategory/5
     [Route("{Id:int}")]
     public IHttpActionResult GetTaxCategory(int Id)
     {
        var taxCategory = _service.GetTaxCategory(Id);
        if (taxCategory == null)
        {
          return NotFound();
        }
        return Ok(taxCategory);
     }

     // POST: api/TaxCategory
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertTaxCategory(JsonConvert.DeserializeObject<TaxCategoryDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/taxCategory", result);
     }

     // PUT: api/TaxCategory/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateTaxCategory(Id, JsonConvert.DeserializeObject<TaxCategoryDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/TaxCategory/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteTaxCategory(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
