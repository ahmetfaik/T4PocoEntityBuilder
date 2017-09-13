using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Customer_CustomerRole_Mapping.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Customer_CustomerRole_Mapping 
  {
      [Key, Column(Order = 0)]
   public int Customer_Id { get; set; }

      [Key, Column(Order = 1)]
   public int CustomerRole_Id { get; set; }
  }
}
