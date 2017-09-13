using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a MeasureWeight.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class MeasureWeight 
  {
      [Key]
   public int Id { get; set; }

   public string Name { get; set; }

   public string SystemKeyword { get; set; }

   public decimal Ratio { get; set; }

   public int DisplayOrder { get; set; }
  }
}
