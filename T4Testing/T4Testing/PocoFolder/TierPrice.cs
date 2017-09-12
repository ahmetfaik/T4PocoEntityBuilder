using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a TierPrice.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class TierPrice 
  {
      [Key]
   public int Id { get; set; }

   public int ProductId { get; set; }

   public int StoreId { get; set; }

   public int? CustomerRoleId { get; set; }

   public int Quantity { get; set; }

   public decimal Price { get; set; }

   public DateTime? StartDateTimeUtc { get; set; }

   public DateTime? EndDateTimeUtc { get; set; }
  }
}
