using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventsApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EventsController : ControllerBase
  {
    private readonly EventService _eventService;

    public EventsController(EventService eventService)
    {
      _eventService = eventService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEvents()
    {
      var response = await _eventService.GetAllEventsAsync();

      return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEvent(string id)
    {
      var response = await _eventService.GetEventByIdAsync(id);

      return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEvent(EventModel model)
    {
      if (model == null)
        return BadRequest("Event model is null.");
      var result = await _eventService.Create(model);
      if (!result)
        return BadRequest("Failed to create event.");

      return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveEvent(string id)
    {
      if (string.IsNullOrEmpty(id))
        return BadRequest("Event ID is null or empty.");
      var result = await _eventService.Remove(id);
      if (!result)
        return NotFound("Event not found.");
      return Ok();
    }
  }
}
