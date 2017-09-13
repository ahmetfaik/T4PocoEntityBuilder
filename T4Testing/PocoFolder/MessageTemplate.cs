using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a MessageTemplate.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class MessageTemplate 
  {
      [Key]
   public int Id { get; set; }

   public string Name { get; set; }

   public string BccEmailAddresses { get; set; }

   public string Subject { get; set; }

   public string Body { get; set; }

   public bool IsActive { get; set; }

   public int? DelayBeforeSend { get; set; }

   public int DelayPeriodId { get; set; }

   public int AttachedDownloadId { get; set; }

   public int EmailAccountId { get; set; }

   public bool LimitedToStores { get; set; }
  }
}
