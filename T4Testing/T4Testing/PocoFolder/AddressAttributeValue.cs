using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a AddressAttributeValue.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class AddressAttributeValue 
  {
      [Key]
   public int Id { get; set; }

   public int AddressAttributeId { get; set; }

   public string Name { get; set; }

   public bool IsPreSelected { get; set; }

   public int DisplayOrder { get; set; }
  }
}
