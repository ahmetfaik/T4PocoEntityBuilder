using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Currency.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Currency 
  {
      [Key]
   public int Id { get; set; }

   public string Name { get; set; }

   public string CurrencyCode { get; set; }

   public decimal Rate { get; set; }

   public string DisplayLocale { get; set; }

   public string CustomFormatting { get; set; }

   public bool LimitedToStores { get; set; }

   public bool Published { get; set; }

   public int DisplayOrder { get; set; }

   public DateTime CreatedOnUtc { get; set; }

   public DateTime UpdatedOnUtc { get; set; }

   public int RoundingTypeId { get; set; }
  }
}
