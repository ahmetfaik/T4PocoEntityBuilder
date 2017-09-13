using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Shipment.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Shipment 
  {
      [Key]
   public int Id { get; set; }

   public int OrderId { get; set; }

   public string TrackingNumber { get; set; }

   public decimal? TotalWeight { get; set; }

   public DateTime? ShippedDateUtc { get; set; }

   public DateTime? DeliveryDateUtc { get; set; }

   public string AdminComment { get; set; }

   public DateTime CreatedOnUtc { get; set; }
  }
}
