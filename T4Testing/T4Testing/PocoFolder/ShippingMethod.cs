using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a ShippingMethod.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class ShippingMethod 
  {
      [Key]
   public int Id { get; set; }

   public string Name { get; set; }

   public string Description { get; set; }

   public int DisplayOrder { get; set; }
  }
}