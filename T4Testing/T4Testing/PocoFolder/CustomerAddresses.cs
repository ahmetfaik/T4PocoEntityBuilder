using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a CustomerAddresses.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class CustomerAddresses 
  {
      [Key, Column(Order = 0)]
   public int Customer_Id { get; set; }

      [Key, Column(Order = 1)]
   public int Address_Id { get; set; }
  }
}
