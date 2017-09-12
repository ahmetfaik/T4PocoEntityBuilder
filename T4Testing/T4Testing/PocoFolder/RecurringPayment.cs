using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a RecurringPayment.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class RecurringPayment 
  {
      [Key]
   public int Id { get; set; }

   public int CycleLength { get; set; }

   public int CyclePeriodId { get; set; }

   public int TotalCycles { get; set; }

   public DateTime StartDateUtc { get; set; }

   public bool IsActive { get; set; }

   public bool LastPaymentFailed { get; set; }

   public bool Deleted { get; set; }

   public int InitialOrderId { get; set; }

   public DateTime CreatedOnUtc { get; set; }
  }
}
