using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models;
public class EventModel
{
  public string Id { get; set; } = null!;
  public string Name { get; set; } = null!;
  public string? Location { get; set; }
  public string? Description { get; set; }
  [Column(TypeName = "datetime2")]
  public DateTime Date { get; set; }
  [Column(TypeName = "datetime2")]
  public DateTime Time { get; set; }
}
