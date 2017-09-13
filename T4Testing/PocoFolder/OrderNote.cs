using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a OrderNote.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class OrderNote 
  {
      [Key]
   public int Id { get; set; }

   public int OrderId { get; set; }

   public string Note { get; set; }

   public int DownloadId { get; set; }

   public bool DisplayToCustomer { get; set; }

   public DateTime CreatedOnUtc { get; set; }
  }
}
