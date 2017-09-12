using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Discount_AppliedToCategories.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Discount_AppliedToCategories 
  {
      [Key, Column(Order = 0)]
   public int Discount_Id { get; set; }

      [Key, Column(Order = 1)]
   public int Category_Id { get; set; }
  }
}
