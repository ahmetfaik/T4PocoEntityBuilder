using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a SearchTerm.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class SearchTerm 
  {
      [Key]
   public int Id { get; set; }

   public string Keyword { get; set; }

   public int StoreId { get; set; }

   public int Count { get; set; }
  }
}
