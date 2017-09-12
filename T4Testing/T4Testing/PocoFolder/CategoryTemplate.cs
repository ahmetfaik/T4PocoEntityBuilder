using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a CategoryTemplate.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class CategoryTemplate 
  {
      [Key]
   public int Id { get; set; }

   public string Name { get; set; }

   public string ViewPath { get; set; }

   public int DisplayOrder { get; set; }
  }
}
