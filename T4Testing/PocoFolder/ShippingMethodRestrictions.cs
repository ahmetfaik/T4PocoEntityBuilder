using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a ShippingMethodRestrictions.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class ShippingMethodRestrictions 
  {
      [Key, Column(Order = 0)]
   public int ShippingMethod_Id { get; set; }

      [Key, Column(Order = 1)]
   public int Country_Id { get; set; }
  }
}
