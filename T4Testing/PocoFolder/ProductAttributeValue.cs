using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a ProductAttributeValue.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class ProductAttributeValue 
  {
      [Key]
   public int Id { get; set; }

   public int ProductAttributeMappingId { get; set; }

   public int AttributeValueTypeId { get; set; }

   public int AssociatedProductId { get; set; }

   public string Name { get; set; }

   public string ColorSquaresRgb { get; set; }

   public int ImageSquaresPictureId { get; set; }

   public decimal PriceAdjustment { get; set; }

   public decimal WeightAdjustment { get; set; }

   public decimal Cost { get; set; }

   public bool CustomerEntersQty { get; set; }

   public int Quantity { get; set; }

   public bool IsPreSelected { get; set; }

   public int DisplayOrder { get; set; }

   public int PictureId { get; set; }
  }
}
