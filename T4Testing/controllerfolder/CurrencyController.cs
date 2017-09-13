using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/currency")]
   public class CurrencyController : ApiController
   {
     ICurrencyDTOService _service;

     public CurrencyController(ICurrencyDTOService service)
     {
        this._service = service;
     }

     // GET: api/Currency
     [Route("")]
     public IEnumerable<CurrencyDTO> Get()
     {
        return _service.GetAllCurrency();
     }

     // GET: api/Currency/5
     [Route("{Id:int}")]
     public IHttpActionResult GetCurrency(int Id)
     {
        var currency = _service.GetCurrency(Id);
        if (currency == null)
        {
          return NotFound();
        }
        return Ok(currency);
     }

     // POST: api/Currency
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertCurrency(JsonConvert.DeserializeObject<CurrencyDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/currency", result);
     }

     // PUT: api/Currency/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateCurrency(Id, JsonConvert.DeserializeObject<CurrencyDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Currency/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteCurrency(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
