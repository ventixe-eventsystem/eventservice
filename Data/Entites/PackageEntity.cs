using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entites;

public class PackageEntity
{
  [Key]
  public int Id { get; set; }
  public string Name { get; set; } = null!;
  [Column(TypeName = "decimal(18,2)")]
  public decimal Price { get; set; }
}