using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a LocalizedProperty.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class LocalizedProperty 
  {
      [Key]
   public int Id { get; set; }

   public int EntityId { get; set; }

   public int LanguageId { get; set; }

   public string LocaleKeyGroup { get; set; }

   public string LocaleKey { get; set; }

   public string LocaleValue { get; set; }
  }
}
