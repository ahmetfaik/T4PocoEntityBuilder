using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a CustomerAttribute.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class CustomerAttribute 
  {
      [Key]
   public int Id { get; set; }

   public string Name { get; set; }

   public bool IsRequired { get; set; }

   public int AttributeControlTypeId { get; set; }

   public int DisplayOrder { get; set; }
  }
}
