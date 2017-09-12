using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Log.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Log 
  {
      [Key]
   public int Id { get; set; }

   public int LogLevelId { get; set; }

   public string ShortMessage { get; set; }

   public string FullMessage { get; set; }

   public string IpAddress { get; set; }

   public int? CustomerId { get; set; }

   public string PageUrl { get; set; }

   public string ReferrerUrl { get; set; }

   public DateTime CreatedOnUtc { get; set; }
  }
}
