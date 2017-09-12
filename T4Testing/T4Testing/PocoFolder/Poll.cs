using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Poll.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Poll 
  {
      [Key]
   public int Id { get; set; }

   public int LanguageId { get; set; }

   public string Name { get; set; }

   public string SystemKeyword { get; set; }

   public bool Published { get; set; }

   public bool ShowOnHomePage { get; set; }

   public bool AllowGuestsToVote { get; set; }

   public int DisplayOrder { get; set; }

   public DateTime? StartDateUtc { get; set; }

   public DateTime? EndDateUtc { get; set; }
  }
}
