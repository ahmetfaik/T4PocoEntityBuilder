using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Store.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Store 
  {
      [Key]
   public int Id { get; set; }

   public string Name { get; set; }

   public string Url { get; set; }

   public bool SslEnabled { get; set; }

   public string SecureUrl { get; set; }

   public string Hosts { get; set; }

   public int DefaultLanguageId { get; set; }

   public int DisplayOrder { get; set; }

   public string CompanyName { get; set; }

   public string CompanyAddress { get; set; }

   public string CompanyPhoneNumber { get; set; }

   public string CompanyVat { get; set; }
  }
}
