using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a RewardPointsHistory.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class RewardPointsHistory 
  {
      [Key]
   public int Id { get; set; }

   public int CustomerId { get; set; }

   public int StoreId { get; set; }

   public int Points { get; set; }

   public int? PointsBalance { get; set; }

   public decimal UsedAmount { get; set; }

   public string Message { get; set; }

   public DateTime CreatedOnUtc { get; set; }

   public int? UsedWithOrder_Id { get; set; }
  }
}
