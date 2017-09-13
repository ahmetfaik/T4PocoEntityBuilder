using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a StateProvince.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class StateProvince 
  {
      [Key]
   public int Id { get; set; }

   public int CountryId { get; set; }

   public string Name { get; set; }

   public string Abbreviation { get; set; }

   public bool Published { get; set; }

   public int DisplayOrder { get; set; }
  }
}
