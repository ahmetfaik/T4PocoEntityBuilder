using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a VendorNote.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class VendorNote 
  {
      [Key]
   public int Id { get; set; }

   public int VendorId { get; set; }

   public string Note { get; set; }

   public DateTime CreatedOnUtc { get; set; }
  }
}
