using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a RelatedProduct.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class RelatedProduct 
  {
      [Key]
   public int Id { get; set; }

   public int ProductId1 { get; set; }

   public int ProductId2 { get; set; }

   public int DisplayOrder { get; set; }
  }
}
