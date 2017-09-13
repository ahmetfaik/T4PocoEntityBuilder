using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a ShoppingCartItem.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class ShoppingCartItem 
  {
      [Key]
   public int Id { get; set; }

   public int StoreId { get; set; }

   public int ShoppingCartTypeId { get; set; }

   public int CustomerId { get; set; }

   public int ProductId { get; set; }

   public string AttributesXml { get; set; }

   public decimal CustomerEnteredPrice { get; set; }

   public int Quantity { get; set; }

   public DateTime? RentalStartDateUtc { get; set; }

   public DateTime? RentalEndDateUtc { get; set; }

   public DateTime CreatedOnUtc { get; set; }

   public DateTime UpdatedOnUtc { get; set; }
  }
}
