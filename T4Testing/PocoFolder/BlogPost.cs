using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a BlogPost.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class BlogPost 
  {
      [Key]
   public int Id { get; set; }

   public int LanguageId { get; set; }

   public string Title { get; set; }

   public string Body { get; set; }

   public string BodyOverview { get; set; }

   public bool AllowComments { get; set; }

   public string Tags { get; set; }

   public DateTime? StartDateUtc { get; set; }

   public DateTime? EndDateUtc { get; set; }

   public string MetaKeywords { get; set; }

   public string MetaDescription { get; set; }

   public string MetaTitle { get; set; }

   public bool LimitedToStores { get; set; }

   public DateTime CreatedOnUtc { get; set; }
  }
}
