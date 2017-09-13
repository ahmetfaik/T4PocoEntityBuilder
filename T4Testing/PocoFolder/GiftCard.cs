using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a GiftCard.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class GiftCard 
  {
      [Key]
   public int Id { get; set; }

   public int? PurchasedWithOrderItemId { get; set; }

   public int GiftCardTypeId { get; set; }

   public decimal Amount { get; set; }

   public bool IsGiftCardActivated { get; set; }

   public string GiftCardCouponCode { get; set; }

   public string RecipientName { get; set; }

   public string RecipientEmail { get; set; }

   public string SenderName { get; set; }

   public string SenderEmail { get; set; }

   public string Message { get; set; }

   public bool IsRecipientNotified { get; set; }

   public DateTime CreatedOnUtc { get; set; }
  }
}
