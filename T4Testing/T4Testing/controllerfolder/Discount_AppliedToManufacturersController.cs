using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/discount_AppliedToManufacturers")]
   public class Discount_AppliedToManufacturersController : ApiController
   {
     IDiscount_AppliedToManufacturersDTOService _service;

     public Discount_AppliedToManufacturersController(IDiscount_AppliedToManufacturersDTOService service)
     {
        this._service = service;
     }

     // GET: api/Discount_AppliedToManufacturers
     [Route("")]
     public IEnumerable<Discount_AppliedToManufacturersDTO> Get()
     {
        return _service.GetAllDiscount_AppliedToManufacturers();
     }

     // GET: api/Discount_AppliedToManufacturers/5
     [Route("{Discount_Id:int}/{Manufacturer_Id:int}")]
     public IHttpActionResult GetDiscount_AppliedToManufacturers(int Discount_Id, int Manufacturer_Id)
     {
        var discount_AppliedToManufacturers = _service.GetDiscount_AppliedToManufacturers(Discount_Id, Manufacturer_Id);
        if (discount_AppliedToManufacturers == null)
        {
          return NotFound();
        }
        return Ok(discount_AppliedToManufacturers);
     }

     // POST: api/Discount_AppliedToManufacturers
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertDiscount_AppliedToManufacturers(JsonConvert.DeserializeObject<Discount_AppliedToManufacturersDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/discount_AppliedToManufacturers", result);
     }

     // PUT: api/Discount_AppliedToManufacturers/5
     [Route("{Discount_Id:int}/{Manufacturer_Id:int}")]
     public IHttpActionResult Put(int Discount_Id, int Manufacturer_Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateDiscount_AppliedToManufacturers(Discount_Id, Manufacturer_Id, JsonConvert.DeserializeObject<Discount_AppliedToManufacturersDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Discount_AppliedToManufacturers/5
    [Route("{Discount_Id:int}/{Manufacturer_Id:int}")]
    public IHttpActionResult Delete(int Discount_Id, int Manufacturer_Id)
    {
       var result = _service.DeleteDiscount_AppliedToManufacturers(Discount_Id, Manufacturer_Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
