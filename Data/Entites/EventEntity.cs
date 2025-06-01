using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entites;
public class EventEntity
{
  [Key]
  public string Id { get; set; } = Guid.NewGuid().ToString();
  public string Name { get; set; } = null!;
  public string? Location { get; set; }
  public string? Description { get; set; }
  [Column(TypeName = "datetime2")]
  public DateTime DateAndTime { get; set; }
  public int MaxAttendees { get; set; }
  public ICollection<EventPackageEntity> Packages { get; set; } = [];
}
