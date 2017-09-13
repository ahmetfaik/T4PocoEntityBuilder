using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Picture.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Picture 
  {
      [Key]
   public int Id { get; set; }

   public byte[]? PictureBinary { get; set; }

   public string MimeType { get; set; }

   public string SeoFilename { get; set; }

   public string AltAttribute { get; set; }

   public string TitleAttribute { get; set; }

   public bool IsNew { get; set; }
  }
}
