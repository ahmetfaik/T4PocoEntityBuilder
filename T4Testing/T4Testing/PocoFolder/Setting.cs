using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Setting.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Setting 
  {
      [Key]
   public int Id { get; set; }

   public string Name { get; set; }

   public string Value { get; set; }

   public int StoreId { get; set; }
  }
}
