using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Category.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Category 
  {
      [Key]
   public int Id { get; set; }

   public string Name { get; set; }

   public string Description { get; set; }

   public int CategoryTemplateId { get; set; }

   public string MetaKeywords { get; set; }

   public string MetaDescription { get; set; }

   public string MetaTitle { get; set; }

   public int ParentCategoryId { get; set; }

   public int PictureId { get; set; }

   public int PageSize { get; set; }

   public bool AllowCustomersToSelectPageSize { get; set; }

   public string PageSizeOptions { get; set; }

   public string PriceRanges { get; set; }

   public bool ShowOnHomePage { get; set; }

   public bool IncludeInTopMenu { get; set; }

   public bool SubjectToAcl { get; set; }

   public bool LimitedToStores { get; set; }

   public bool Published { get; set; }

   public bool Deleted { get; set; }

   public int DisplayOrder { get; set; }

   public DateTime CreatedOnUtc { get; set; }

   public DateTime UpdatedOnUtc { get; set; }
  }
}
