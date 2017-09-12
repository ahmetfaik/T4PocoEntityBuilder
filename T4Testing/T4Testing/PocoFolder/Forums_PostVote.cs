using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Forums_PostVote.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Forums_PostVote 
  {
      [Key]
   public int Id { get; set; }

   public int ForumPostId { get; set; }

   public int CustomerId { get; set; }

   public bool IsUp { get; set; }

   public DateTime CreatedOnUtc { get; set; }
  }
}
