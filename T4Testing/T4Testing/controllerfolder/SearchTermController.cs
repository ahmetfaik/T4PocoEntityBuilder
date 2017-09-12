using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/searchTerm")]
   public class SearchTermController : ApiController
   {
     ISearchTermDTOService _service;

     public SearchTermController(ISearchTermDTOService service)
     {
        this._service = service;
     }

     // GET: api/SearchTerm
     [Route("")]
     public IEnumerable<SearchTermDTO> Get()
     {
        return _service.GetAllSearchTerm();
     }

     // GET: api/SearchTerm/5
     [Route("{Id:int}")]
     public IHttpActionResult GetSearchTerm(int Id)
     {
        var searchTerm = _service.GetSearchTerm(Id);
        if (searchTerm == null)
        {
          return NotFound();
        }
        return Ok(searchTerm);
     }

     // POST: api/SearchTerm
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertSearchTerm(JsonConvert.DeserializeObject<SearchTermDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/searchTerm", result);
     }

     // PUT: api/SearchTerm/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateSearchTerm(Id, JsonConvert.DeserializeObject<SearchTermDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/SearchTerm/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeleteSearchTerm(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
