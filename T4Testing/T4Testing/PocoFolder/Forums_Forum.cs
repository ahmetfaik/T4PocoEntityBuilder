using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Forums_Forum.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Forums_Forum 
  {
      [Key]
   public int Id { get; set; }

   public int ForumGroupId { get; set; }

   public string Name { get; set; }

   public string Description { get; set; }

   public int NumTopics { get; set; }

   public int NumPosts { get; set; }

   public int LastTopicId { get; set; }

   public int LastPostId { get; set; }

   public int LastPostCustomerId { get; set; }

   public DateTime? LastPostTime { get; set; }

   public int DisplayOrder { get; set; }

   public DateTime CreatedOnUtc { get; set; }

   public DateTime UpdatedOnUtc { get; set; }
  }
}
