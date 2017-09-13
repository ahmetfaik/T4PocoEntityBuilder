using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a UrlRecord.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class UrlRecord 
  {
      [Key]
   public int Id { get; set; }

   public int EntityId { get; set; }

   public string EntityName { get; set; }

   public string Slug { get; set; }

   public bool IsActive { get; set; }

   public int LanguageId { get; set; }
  }
}
