using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Forums_Subscription.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Forums_Subscription 
  {
      [Key]
   public int Id { get; set; }

   public Guid SubscriptionGuid { get; set; }

   public int CustomerId { get; set; }

   public int ForumId { get; set; }

   public int TopicId { get; set; }

   public DateTime CreatedOnUtc { get; set; }
  }
}
