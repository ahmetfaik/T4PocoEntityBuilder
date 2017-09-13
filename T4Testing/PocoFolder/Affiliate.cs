using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4Testing
{
  /// <summary>
  /// Represents a Affiliate.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class Affiliate 
  {
      [Key]
   public int Id { get; set; }

   public int AddressId { get; set; }

   public string AdminComment { get; set; }

   public string FriendlyUrlName { get; set; }

   public bool Deleted { get; set; }

   public bool Active { get; set; }
  }
}
