using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a User.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class User 
  {
      [Key]
   public int Id { get; set; }

   public string UserName { get; set; }

   public string Email { get; set; }
  }
}
