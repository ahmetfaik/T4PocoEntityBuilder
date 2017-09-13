using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a CheckoutAttribute.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class CheckoutAttribute 
  {
      [Key]
   public int Id { get; set; }

   public string Name { get; set; }

   public string TextPrompt { get; set; }

   public bool IsRequired { get; set; }

   public bool ShippableProductRequired { get; set; }

   public bool IsTaxExempt { get; set; }

   public int TaxCategoryId { get; set; }

   public int AttributeControlTypeId { get; set; }

   public int DisplayOrder { get; set; }

   public bool LimitedToStores { get; set; }

   public int? ValidationMinLength { get; set; }

   public int? ValidationMaxLength { get; set; }

   public string ValidationFileAllowedExtensions { get; set; }

   public int? ValidationFileMaximumSize { get; set; }

   public string DefaultValue { get; set; }

   public string ConditionAttributeXml { get; set; }
  }
}
