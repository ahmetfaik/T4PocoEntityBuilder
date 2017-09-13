using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Product_Manufacturer_Mapping.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Product_Manufacturer_Mapping 
  {
      [Key]
   public int Id { get; set; }

   public int ProductId { get; set; }

   public int ManufacturerId { get; set; }

   public bool IsFeaturedProduct { get; set; }

   public int DisplayOrder { get; set; }
  }
}
