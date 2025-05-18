using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models;
public class EventModel
{
  public string? Id { get; set; }
  public string Name { get; set; } = null!;
  public string? Location { get; set; }
  public string? Description { get; set; }
 
  public DateTime Date { get; set; }

  public DateTime Time { get; set; }
}
