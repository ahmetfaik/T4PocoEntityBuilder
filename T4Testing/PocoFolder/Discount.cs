using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Discount.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Discount 
  {
      [Key]
   public int Id { get; set; }

   public string Name { get; set; }

   public int DiscountTypeId { get; set; }

   public bool UsePercentage { get; set; }

   public decimal DiscountPercentage { get; set; }

   public decimal DiscountAmount { get; set; }

   public decimal? MaximumDiscountAmount { get; set; }

   public DateTime? StartDateUtc { get; set; }

   public DateTime? EndDateUtc { get; set; }

   public bool RequiresCouponCode { get; set; }

   public string CouponCode { get; set; }

   public bool IsCumulative { get; set; }

   public int DiscountLimitationId { get; set; }

   public int LimitationTimes { get; set; }

   public int? MaximumDiscountedQuantity { get; set; }

   public bool AppliedToSubCategories { get; set; }
  }
}
