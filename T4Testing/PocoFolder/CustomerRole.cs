using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a CustomerRole.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class CustomerRole 
  {
      [Key]
   public int Id { get; set; }

   public string Name { get; set; }

   public bool FreeShipping { get; set; }

   public bool TaxExempt { get; set; }

   public bool Active { get; set; }

   public bool IsSystemRole { get; set; }

   public string SystemName { get; set; }

   public bool EnablePasswordLifetime { get; set; }

   public int PurchasedWithProductId { get; set; }
  }
}
