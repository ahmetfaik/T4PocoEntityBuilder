using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Product_ProductTag_Mapping.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Product_ProductTag_Mapping 
  {
      [Key, Column(Order = 0)]
   public int Product_Id { get; set; }

      [Key, Column(Order = 1)]
   public int ProductTag_Id { get; set; }
  }
}
