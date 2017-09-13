using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a OrderItem.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class OrderItem 
  {
      [Key]
   public int Id { get; set; }

   public Guid OrderItemGuid { get; set; }

   public int OrderId { get; set; }

   public int ProductId { get; set; }

   public int Quantity { get; set; }

   public decimal UnitPriceInclTax { get; set; }

   public decimal UnitPriceExclTax { get; set; }

   public decimal PriceInclTax { get; set; }

   public decimal PriceExclTax { get; set; }

   public decimal DiscountAmountInclTax { get; set; }

   public decimal DiscountAmountExclTax { get; set; }

   public decimal OriginalProductCost { get; set; }

   public string AttributeDescription { get; set; }

   public string AttributesXml { get; set; }

   public int DownloadCount { get; set; }

   public bool IsDownloadActivated { get; set; }

   public int? LicenseDownloadId { get; set; }

   public decimal? ItemWeight { get; set; }

   public DateTime? RentalStartDateUtc { get; set; }

   public DateTime? RentalEndDateUtc { get; set; }
  }
}
