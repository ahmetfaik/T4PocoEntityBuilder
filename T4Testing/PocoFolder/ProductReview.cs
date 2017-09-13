using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a ProductReview.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class ProductReview 
  {
      [Key]
   public int Id { get; set; }

   public int CustomerId { get; set; }

   public int ProductId { get; set; }

   public int StoreId { get; set; }

   public bool IsApproved { get; set; }

   public string Title { get; set; }

   public string ReviewText { get; set; }

   public string ReplyText { get; set; }

   public int Rating { get; set; }

   public int HelpfulYesTotal { get; set; }

   public int HelpfulNoTotal { get; set; }

   public DateTime CreatedOnUtc { get; set; }
  }
}
