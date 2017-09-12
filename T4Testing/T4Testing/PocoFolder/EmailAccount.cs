using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a EmailAccount.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class EmailAccount 
  {
      [Key]
   public int Id { get; set; }

   public string Email { get; set; }

   public string DisplayName { get; set; }

   public string Host { get; set; }

   public int Port { get; set; }

   public string Username { get; set; }

   public string Password { get; set; }

   public bool EnableSsl { get; set; }

   public bool UseDefaultCredentials { get; set; }
  }
}
