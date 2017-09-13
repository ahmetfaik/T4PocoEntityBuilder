using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a CustomerPassword.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class CustomerPassword 
  {
      [Key]
   public int Id { get; set; }

   public int CustomerId { get; set; }

   public string Password { get; set; }

   public int PasswordFormatId { get; set; }

   public string PasswordSalt { get; set; }

   public DateTime CreatedOnUtc { get; set; }
  }
}
