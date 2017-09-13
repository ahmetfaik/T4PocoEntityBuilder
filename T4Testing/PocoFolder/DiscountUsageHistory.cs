using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a DiscountUsageHistory.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class DiscountUsageHistory 
  {
      [Key]
   public int Id { get; set; }

   public int DiscountId { get; set; }

   public int OrderId { get; set; }

   public DateTime CreatedOnUtc { get; set; }
  }
}
