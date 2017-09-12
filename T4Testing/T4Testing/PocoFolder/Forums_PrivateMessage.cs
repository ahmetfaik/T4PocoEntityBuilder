using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Forums_PrivateMessage.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Forums_PrivateMessage 
  {
      [Key]
   public int Id { get; set; }

   public int StoreId { get; set; }

   public int FromCustomerId { get; set; }

   public int ToCustomerId { get; set; }

   public string Subject { get; set; }

   public string Text { get; set; }

   public bool IsRead { get; set; }

   public bool IsDeletedByAuthor { get; set; }

   public bool IsDeletedByRecipient { get; set; }

   public DateTime CreatedOnUtc { get; set; }
  }
}
