using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a ScheduleTask.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class ScheduleTask 
  {
      [Key]
   public int Id { get; set; }

   public string Name { get; set; }

   public int Seconds { get; set; }

   public string Type { get; set; }

   public bool Enabled { get; set; }

   public bool StopOnError { get; set; }

   public string LeasedByMachineName { get; set; }

   public DateTime? LeasedUntilUtc { get; set; }

   public DateTime? LastStartUtc { get; set; }

   public DateTime? LastEndUtc { get; set; }

   public DateTime? LastSuccessUtc { get; set; }
  }
}
