using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a ProductReviewHelpfulness.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class ProductReviewHelpfulness 
  {
      [Key]
   public int Id { get; set; }

   public int ProductReviewId { get; set; }

   public bool WasHelpful { get; set; }

   public int CustomerId { get; set; }
  }
}
