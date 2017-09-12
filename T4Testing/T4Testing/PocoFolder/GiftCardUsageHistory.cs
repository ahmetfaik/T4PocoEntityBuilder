using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a GiftCardUsageHistory.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class GiftCardUsageHistory 
  {
      [Key]
   public int Id { get; set; }

   public int GiftCardId { get; set; }

   public int UsedWithOrderId { get; set; }

   public decimal UsedValue { get; set; }

   public DateTime CreatedOnUtc { get; set; }
  }
}
