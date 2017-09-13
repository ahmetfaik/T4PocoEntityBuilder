using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Campaign.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Campaign 
  {
      [Key]
   public int Id { get; set; }

   public string Name { get; set; }

   public string Subject { get; set; }

   public string Body { get; set; }

   public int StoreId { get; set; }

   public int CustomerRoleId { get; set; }

   public DateTime CreatedOnUtc { get; set; }

   public DateTime? DontSendBeforeDateUtc { get; set; }
  }
}
