using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/picture")]
   public class PictureController : ApiController
   {
     IPictureDTOService _service;

     public PictureController(IPictureDTOService service)
     {
        this._service = service;
     }

     // GET: api/Picture
     [Route("")]
     public IEnumerable<PictureDTO> Get()
     {
        return _service.GetAllPicture();
     }

     // GET: api/Picture/5
     [Route("{Id:int}")]
     public IHttpActionResult GetPicture(int Id)
     {
        var picture = _service.GetPicture(Id);
        if (picture == null)
        {
          return NotFound();
        }
        return Ok(picture);
     }

     // POST: api/Picture
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertPicture(JsonConvert.DeserializeObject<PictureDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/picture", result);
     }

     // PUT: api/Picture/5
     [Route("{Id:int}")]
     public IHttpActionResult Put(int Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdatePicture(Id, JsonConvert.DeserializeObject<PictureDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Picture/5
    [Route("{Id:int}")]
    public IHttpActionResult Delete(int Id)
    {
       var result = _service.DeletePicture(Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
