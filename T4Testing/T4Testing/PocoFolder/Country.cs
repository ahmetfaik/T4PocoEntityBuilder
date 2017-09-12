using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Country.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Country 
  {
      [Key]
   public int Id { get; set; }

   public string Name { get; set; }

   public bool AllowsBilling { get; set; }

   public bool AllowsShipping { get; set; }

   public string TwoLetterIsoCode { get; set; }

   public string ThreeLetterIsoCode { get; set; }

   public int NumericIsoCode { get; set; }

   public bool SubjectToVat { get; set; }

   public bool Published { get; set; }

   public int DisplayOrder { get; set; }

   public bool LimitedToStores { get; set; }
  }
}
