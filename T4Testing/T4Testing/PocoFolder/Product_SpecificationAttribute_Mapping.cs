using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Product_SpecificationAttribute_Mapping.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Product_SpecificationAttribute_Mapping 
  {
      [Key]
   public int Id { get; set; }

   public int ProductId { get; set; }

   public int AttributeTypeId { get; set; }

   public int SpecificationAttributeOptionId { get; set; }

   public string CustomValue { get; set; }

   public bool AllowFiltering { get; set; }

   public bool ShowOnProductPage { get; set; }

   public int DisplayOrder { get; set; }
  }
}
