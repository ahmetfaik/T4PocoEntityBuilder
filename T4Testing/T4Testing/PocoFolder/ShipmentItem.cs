using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a ShipmentItem.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class ShipmentItem 
  {
      [Key]
   public int Id { get; set; }

   public int ShipmentId { get; set; }

   public int OrderItemId { get; set; }

   public int Quantity { get; set; }

   public int WarehouseId { get; set; }
  }
}
