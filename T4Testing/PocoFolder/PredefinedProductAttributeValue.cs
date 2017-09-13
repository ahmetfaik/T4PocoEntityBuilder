using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a PredefinedProductAttributeValue.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class PredefinedProductAttributeValue 
  {
      [Key]
   public int Id { get; set; }

   public int ProductAttributeId { get; set; }

   public string Name { get; set; }

   public decimal PriceAdjustment { get; set; }

   public decimal WeightAdjustment { get; set; }

   public decimal Cost { get; set; }

   public bool IsPreSelected { get; set; }

   public int DisplayOrder { get; set; }
  }
}
