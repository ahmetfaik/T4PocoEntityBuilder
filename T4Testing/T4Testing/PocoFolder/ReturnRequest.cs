using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a ReturnRequest.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class ReturnRequest 
  {
      [Key]
   public int Id { get; set; }

   public string CustomNumber { get; set; }

   public int StoreId { get; set; }

   public int OrderItemId { get; set; }

   public int CustomerId { get; set; }

   public int Quantity { get; set; }

   public string ReasonForReturn { get; set; }

   public string RequestedAction { get; set; }

   public string CustomerComments { get; set; }

   public int UploadedFileId { get; set; }

   public string StaffNotes { get; set; }

   public int ReturnRequestStatusId { get; set; }

   public DateTime CreatedOnUtc { get; set; }

   public DateTime UpdatedOnUtc { get; set; }
  }
}
