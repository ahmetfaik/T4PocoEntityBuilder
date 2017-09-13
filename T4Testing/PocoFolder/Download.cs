using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Download.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Download 
  {
      [Key]
   public int Id { get; set; }

   public Guid DownloadGuid { get; set; }

   public bool UseDownloadUrl { get; set; }

   public string DownloadUrl { get; set; }

   public byte[]? DownloadBinary { get; set; }

   public string ContentType { get; set; }

   public string Filename { get; set; }

   public string Extension { get; set; }

   public bool IsNew { get; set; }
  }
}
