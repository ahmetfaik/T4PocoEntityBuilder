using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a ProductAttributeCombination.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class ProductAttributeCombination 
  {
      [Key]
   public int Id { get; set; }

   public int ProductId { get; set; }

   public string AttributesXml { get; set; }

   public int StockQuantity { get; set; }

   public bool AllowOutOfStockOrders { get; set; }

   public string Sku { get; set; }

   public string ManufacturerPartNumber { get; set; }

   public string Gtin { get; set; }

   public decimal? OverriddenPrice { get; set; }

   public int NotifyAdminForQuantityBelow { get; set; }
  }
}
