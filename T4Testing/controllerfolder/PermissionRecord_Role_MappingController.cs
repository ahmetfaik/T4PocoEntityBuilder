using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace T4Testing
{
     [RoutePrefix("api/permissionRecord_Role_Mapping")]
   public class PermissionRecord_Role_MappingController : ApiController
   {
     IPermissionRecord_Role_MappingDTOService _service;

     public PermissionRecord_Role_MappingController(IPermissionRecord_Role_MappingDTOService service)
     {
        this._service = service;
     }

     // GET: api/PermissionRecord_Role_Mapping
     [Route("")]
     public IEnumerable<PermissionRecord_Role_MappingDTO> Get()
     {
        return _service.GetAllPermissionRecord_Role_Mapping();
     }

     // GET: api/PermissionRecord_Role_Mapping/5
     [Route("{PermissionRecord_Id:int}/{CustomerRole_Id:int}")]
     public IHttpActionResult GetPermissionRecord_Role_Mapping(int PermissionRecord_Id, int CustomerRole_Id)
     {
        var permissionRecord_Role_Mapping = _service.GetPermissionRecord_Role_Mapping(PermissionRecord_Id, CustomerRole_Id);
        if (permissionRecord_Role_Mapping == null)
        {
          return NotFound();
        }
        return Ok(permissionRecord_Role_Mapping);
     }

     // POST: api/PermissionRecord_Role_Mapping
     [Route("")]
     public IHttpActionResult Post([FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.InsertPermissionRecord_Role_Mapping(JsonConvert.DeserializeObject<PermissionRecord_Role_MappingDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Created("/permissionRecord_Role_Mapping", result);
     }

     // PUT: api/PermissionRecord_Role_Mapping/5
     [Route("{PermissionRecord_Id:int}/{CustomerRole_Id:int}")]
     public IHttpActionResult Put(int PermissionRecord_Id, int CustomerRole_Id, [FromBody]dynamic data)
     {
       string value = data.value;
       var result = _service.UpdatePermissionRecord_Role_Mapping(PermissionRecord_Id, CustomerRole_Id, JsonConvert.DeserializeObject<PermissionRecord_Role_MappingDTO>(value));
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }

    // DELETE: api/PermissionRecord_Role_Mapping/5
    [Route("{PermissionRecord_Id:int}/{CustomerRole_Id:int}")]
    public IHttpActionResult Delete(int PermissionRecord_Id, int CustomerRole_Id)
    {
       var result = _service.DeletePermissionRecord_Role_Mapping(PermissionRecord_Id, CustomerRole_Id);
       if (result.Contains(ResponseMessages.Exception.GetDescription()))
       {
          return BadRequest(result);
       }
       return Ok(result);
    }
  }
}
