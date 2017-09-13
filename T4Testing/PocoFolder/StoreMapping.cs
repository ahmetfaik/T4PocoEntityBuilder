using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a StoreMapping.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class StoreMapping 
  {
      [Key]
   public int Id { get; set; }

   public int EntityId { get; set; }

   public string EntityName { get; set; }

   public int StoreId { get; set; }
  }
}
