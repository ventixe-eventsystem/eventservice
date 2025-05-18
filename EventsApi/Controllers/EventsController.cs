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

      if (response == null || !response.Any())
        return NotFound("No events found.");

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

      return Created();
    }
  }
}
