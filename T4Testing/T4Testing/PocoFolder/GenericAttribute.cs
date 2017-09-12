using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a GenericAttribute.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class GenericAttribute 
  {
      [Key]
   public int Id { get; set; }

   public int EntityId { get; set; }

   public string KeyGroup { get; set; }

   public string Key { get; set; }

   public string Value { get; set; }

   public int StoreId { get; set; }
  }
}
