using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a ProductWarehouseInventory.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class ProductWarehouseInventory 
  {
      [Key]
   public int Id { get; set; }

   public int ProductId { get; set; }

   public int WarehouseId { get; set; }

   public int StockQuantity { get; set; }

   public int ReservedQuantity { get; set; }
  }
}
