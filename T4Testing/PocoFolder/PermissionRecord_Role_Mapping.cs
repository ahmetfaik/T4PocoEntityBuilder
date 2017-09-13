using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a PermissionRecord_Role_Mapping.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class PermissionRecord_Role_Mapping 
  {
      [Key, Column(Order = 0)]
   public int PermissionRecord_Id { get; set; }

      [Key, Column(Order = 1)]
   public int CustomerRole_Id { get; set; }
  }
}
