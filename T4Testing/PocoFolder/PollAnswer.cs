using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a PollAnswer.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class PollAnswer 
  {
      [Key]
   public int Id { get; set; }

   public int PollId { get; set; }

   public string Name { get; set; }

   public int NumberOfVotes { get; set; }

   public int DisplayOrder { get; set; }
  }
}
