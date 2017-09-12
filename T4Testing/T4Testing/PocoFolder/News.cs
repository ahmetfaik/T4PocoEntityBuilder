using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a News.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class News 
  {
      [Key]
   public int Id { get; set; }

   public int LanguageId { get; set; }

   public string Title { get; set; }

   public string Short { get; set; }

   public string Full { get; set; }

   public bool Published { get; set; }

   public DateTime? StartDateUtc { get; set; }

   public DateTime? EndDateUtc { get; set; }

   public bool AllowComments { get; set; }

   public bool LimitedToStores { get; set; }

   public string MetaKeywords { get; set; }

   public string MetaDescription { get; set; }

   public string MetaTitle { get; set; }

   public DateTime CreatedOnUtc { get; set; }
  }
}
