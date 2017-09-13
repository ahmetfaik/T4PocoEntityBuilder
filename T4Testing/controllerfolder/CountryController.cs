using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/country")]
   public class CountryController : ApiController
   {
     ICountryDTOService _service;

     public CountryController(ICountryDTOService service)
     {
        this._service = service;
     }

     // GET: api/Country
     [Route("")]
     public IEnumerable<CountryDTO> Get()
     {
        return _service.GetAllCountry();
     }

     // GET: api/Country/5
     [Route("{Id:int}")]
     public IHttpActionResult GetCountry(int Id)
     {
        var country = _service.GetCountry(Id);
        if (country == null)
        {
          return NotFound();
        }
        return Ok(country);
     }

     // POST: api/Country
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertCountry(JsonConvert.DeserializeObject<CountryDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/country", result);
     }

     // PUT: api/Country/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateCountry(Id, JsonConvert.DeserializeObject<CountryDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Country/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteCountry(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
