using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a QueuedEmail.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class QueuedEmail 
  {
      [Key]
   public int Id { get; set; }

   public int PriorityId { get; set; }

   public string From { get; set; }

   public string FromName { get; set; }

   public string To { get; set; }

   public string ToName { get; set; }

   public string ReplyTo { get; set; }

   public string ReplyToName { get; set; }

   public string CC { get; set; }

   public string Bcc { get; set; }

   public string Subject { get; set; }

   public string Body { get; set; }

   public string AttachmentFilePath { get; set; }

   public string AttachmentFileName { get; set; }

   public int AttachedDownloadId { get; set; }

   public DateTime CreatedOnUtc { get; set; }

   public DateTime? DontSendBeforeDateUtc { get; set; }

   public int SentTries { get; set; }

   public DateTime? SentOnUtc { get; set; }

   public int EmailAccountId { get; set; }
  }
}
