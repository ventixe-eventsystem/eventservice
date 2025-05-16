using Business.Models;
using Data.Entites;
using Data.Interfaces;

namespace Business.Services;
public class EventService(IEventRepository repository)
{
  private readonly IEventRepository _repository = repository;

  public async Task<bool> Create(EventModel model)
  {
    var entity = new EventEntity
    {
      Id = model.Id,
      Name = model.Name,
      Location = model.Location,
      Description = model.Description,
      Date = model.Date,
      Time = model.Time
    };
    var result = await _repository.CreateAsync(entity);
    return result > 0;
  }

  public async Task<IEnumerable<EventModel>> GetAllEventsAsync()
  {

    var respons = await _repository.GetAllAsync();
    var allEvents = respons.Select(e => new EventModel
    {
      Id = e.Id,
      Name = e.Name,
      Location = e.Location,
      Description = e.Description,
      Date = e.Date,
      Time = e.Time
    });

    return allEvents;
  }
}
