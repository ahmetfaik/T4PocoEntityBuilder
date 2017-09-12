using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a StockQuantityHistory.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class StockQuantityHistory 
  {
      [Key]
   public int Id { get; set; }

   public int QuantityAdjustment { get; set; }

   public int StockQuantity { get; set; }

   public string Message { get; set; }

   public DateTime CreatedOnUtc { get; set; }

   public int ProductId { get; set; }

   public int? CombinationId { get; set; }

   public int? WarehouseId { get; set; }
  }
}
