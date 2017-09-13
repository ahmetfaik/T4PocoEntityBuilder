using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a NewsLetterSubscription.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class NewsLetterSubscription 
  {
      [Key]
   public int Id { get; set; }

   public Guid NewsLetterSubscriptionGuid { get; set; }

   public string Email { get; set; }

   public bool Active { get; set; }

   public int StoreId { get; set; }

   public DateTime CreatedOnUtc { get; set; }
  }
}
