using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Forums_Topic.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Forums_Topic 
  {
      [Key]
   public int Id { get; set; }

   public int ForumId { get; set; }

   public int CustomerId { get; set; }

   public int TopicTypeId { get; set; }

   public string Subject { get; set; }

   public int NumPosts { get; set; }

   public int Views { get; set; }

   public int LastPostId { get; set; }

   public int LastPostCustomerId { get; set; }

   public DateTime? LastPostTime { get; set; }

   public DateTime CreatedOnUtc { get; set; }

   public DateTime UpdatedOnUtc { get; set; }
  }
}
