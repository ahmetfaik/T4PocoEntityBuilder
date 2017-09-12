using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Vendor.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Vendor 
  {
      [Key]
   public int Id { get; set; }

   public string Name { get; set; }

   public string Email { get; set; }

   public string Description { get; set; }

   public int PictureId { get; set; }

   public int AddressId { get; set; }

   public string AdminComment { get; set; }

   public bool Active { get; set; }

   public bool Deleted { get; set; }

   public int DisplayOrder { get; set; }

   public string MetaKeywords { get; set; }

   public string MetaDescription { get; set; }

   public string MetaTitle { get; set; }

   public int PageSize { get; set; }

   public bool AllowCustomersToSelectPageSize { get; set; }

   public string PageSizeOptions { get; set; }
  }
}
