using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a ExternalAuthenticationRecord.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class ExternalAuthenticationRecord 
  {
      [Key]
   public int Id { get; set; }

   public int CustomerId { get; set; }

   public string Email { get; set; }

   public string ExternalIdentifier { get; set; }

   public string ExternalDisplayIdentifier { get; set; }

   public string OAuthToken { get; set; }

   public string OAuthAccessToken { get; set; }

   public string ProviderSystemName { get; set; }
  }
}
