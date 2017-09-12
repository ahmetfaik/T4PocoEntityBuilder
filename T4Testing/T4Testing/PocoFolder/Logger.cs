using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Logger.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Logger 
  {
      [Key]
   public int Id { get; set; }

   public string LogType { get; set; }

   public string Description { get; set; }
  }
}
