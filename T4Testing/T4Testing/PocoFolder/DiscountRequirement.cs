using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a DiscountRequirement.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class DiscountRequirement 
  {
      [Key]
   public int Id { get; set; }

   public int DiscountId { get; set; }

   public string DiscountRequirementRuleSystemName { get; set; }

   public int? ParentId { get; set; }

   public int? InteractionTypeId { get; set; }

   public bool IsGroup { get; set; }
  }
}
