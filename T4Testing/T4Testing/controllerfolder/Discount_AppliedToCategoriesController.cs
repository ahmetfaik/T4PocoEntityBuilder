using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/discount_AppliedToCategories")]
   public class Discount_AppliedToCategoriesController : ApiController
   {
     IDiscount_AppliedToCategoriesDTOService _service;

     public Discount_AppliedToCategoriesController(IDiscount_AppliedToCategoriesDTOService service)
     {
        this._service = service;
     }

     // GET: api/Discount_AppliedToCategories
     [Route("")]
     public IEnumerable<Discount_AppliedToCategoriesDTO> Get()
     {
        return _service.GetAllDiscount_AppliedToCategories();
     }

     // GET: api/Discount_AppliedToCategories/5
     [Route("{Discount_Id:int}/{Category_Id:int}")]
     public IHttpActionResult GetDiscount_AppliedToCategories(int Discount_Id, int Category_Id)
     {
        var discount_AppliedToCategories = _service.GetDiscount_AppliedToCategories(Discount_Id, Category_Id);
        if (discount_AppliedToCategories == null)
        {
          return NotFound();
        }
        return Ok(discount_AppliedToCategories);
     }

     // POST: api/Discount_AppliedToCategories
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertDiscount_AppliedToCategories(JsonConvert.DeserializeObject<Discount_AppliedToCategoriesDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/discount_AppliedToCategories", result);
     }

     // PUT: api/Discount_AppliedToCategories/5
     [Route("{Discount_Id:int}/{Category_Id:int}")]
     public IHttpActionResult Put(int Discount_Id, int Category_Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdateDiscount_AppliedToCategories(Discount_Id, Category_Id, JsonConvert.DeserializeObject<Discount_AppliedToCategoriesDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/Discount_AppliedToCategories/5
    [Route("{Discount_Id:int}/{Category_Id:int}")]
    public IHttpActionResult Delete(int Discount_Id, int Category_Id)
    {
       var result = _service.DeleteDiscount_AppliedToCategories(Discount_Id, Category_Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
