using Business.Models;

namespace Business.Interfaces;

public interface IEventService
{
  Task<bool> Create(EventModel model);
  Task<IEnumerable<EventModel>> GetAllEventsAsync();
  Task<EventModel> GetEventByIdAsync(string id);
  Task<bool> Remove(string id);
}