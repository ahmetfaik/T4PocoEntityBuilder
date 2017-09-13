using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a NewsComment.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class NewsComment 
  {
      [Key]
   public int Id { get; set; }

   public string CommentTitle { get; set; }

   public string CommentText { get; set; }

   public int NewsItemId { get; set; }

   public int CustomerId { get; set; }

   public bool IsApproved { get; set; }

   public int StoreId { get; set; }

   public DateTime CreatedOnUtc { get; set; }
  }
}
