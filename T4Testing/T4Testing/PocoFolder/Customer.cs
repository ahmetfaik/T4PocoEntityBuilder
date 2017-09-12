using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Customer.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Customer 
  {
      [Key]
   public int Id { get; set; }

   public Guid CustomerGuid { get; set; }

   public string Username { get; set; }

   public string Email { get; set; }

   public string EmailToRevalidate { get; set; }

   public string AdminComment { get; set; }

   public bool IsTaxExempt { get; set; }

   public int AffiliateId { get; set; }

   public int VendorId { get; set; }

   public bool HasShoppingCartItems { get; set; }

   public bool RequireReLogin { get; set; }

   public int FailedLoginAttempts { get; set; }

   public DateTime? CannotLoginUntilDateUtc { get; set; }

   public bool Active { get; set; }

   public bool Deleted { get; set; }

   public bool IsSystemAccount { get; set; }

   public string SystemName { get; set; }

   public string LastIpAddress { get; set; }

   public DateTime CreatedOnUtc { get; set; }

   public DateTime? LastLoginDateUtc { get; set; }

   public DateTime LastActivityDateUtc { get; set; }

   public int RegisteredInStoreId { get; set; }

   public int? BillingAddress_Id { get; set; }

   public int? ShippingAddress_Id { get; set; }
  }
}
