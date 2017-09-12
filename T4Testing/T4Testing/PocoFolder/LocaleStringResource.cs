using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a LocaleStringResource.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class LocaleStringResource 
  {
      [Key]
   public int Id { get; set; }

   public int LanguageId { get; set; }

   public string ResourceName { get; set; }

   public string ResourceValue { get; set; }
  }
}
