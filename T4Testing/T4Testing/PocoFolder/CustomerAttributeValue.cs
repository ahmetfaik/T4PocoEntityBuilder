using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a CustomerAttributeValue.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class CustomerAttributeValue 
  {
      [Key]
   public int Id { get; set; }

   public int CustomerAttributeId { get; set; }

   public string Name { get; set; }

   public bool IsPreSelected { get; set; }

   public int DisplayOrder { get; set; }
  }
}
