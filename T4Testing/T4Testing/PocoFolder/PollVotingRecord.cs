using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a PollVotingRecord.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class PollVotingRecord 
  {
      [Key]
   public int Id { get; set; }

   public int PollAnswerId { get; set; }

   public int CustomerId { get; set; }

   public DateTime CreatedOnUtc { get; set; }
  }
}
