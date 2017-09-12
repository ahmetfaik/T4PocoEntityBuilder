using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a ActivityLog.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class ActivityLog 
  {
      [Key]
   public int Id { get; set; }

   public int ActivityLogTypeId { get; set; }

   public int CustomerId { get; set; }

   public string Comment { get; set; }

   public DateTime CreatedOnUtc { get; set; }

   public string IpAddress { get; set; }
  }
}
