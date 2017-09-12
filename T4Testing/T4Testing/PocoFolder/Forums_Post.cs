using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Forums_Post.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Forums_Post 
  {
      [Key]
   public int Id { get; set; }

   public int TopicId { get; set; }

   public int CustomerId { get; set; }

   public string Text { get; set; }

   public string IPAddress { get; set; }

   public DateTime CreatedOnUtc { get; set; }

   public DateTime UpdatedOnUtc { get; set; }

   public int VoteCount { get; set; }
  }
}
