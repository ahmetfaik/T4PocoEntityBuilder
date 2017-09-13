using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Language.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Language 
  {
      [Key]
   public int Id { get; set; }

   public string Name { get; set; }

   public string LanguageCulture { get; set; }

   public string UniqueSeoCode { get; set; }

   public string FlagImageFileName { get; set; }

   public bool Rtl { get; set; }

   public bool LimitedToStores { get; set; }

   public int DefaultCurrencyId { get; set; }

   public bool Published { get; set; }

   public int DisplayOrder { get; set; }
  }
}
