using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventsApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class EventsController(IEventService eventService) : ControllerBase
{
  private readonly IEventService _eventService = eventService;

  [HttpGet]
  public async Task<IActionResult> GetAllEvents()
  {
    try
    {
      var response = await _eventService.GetAllEventsAsync();
      if (response == null || !response.Any())
        return NotFound("No events found.");

      return Ok(response);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"An error occurred while retrieving events: {ex.Message}");
    }
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetEvent(string id)
  {
    if (string.IsNullOrEmpty(id))
      return BadRequest("Event ID is null or empty.");
    try
    {
      var response = await _eventService.GetEventByIdAsync(id);
      if (response == null)
        return NotFound($"Event with ID {id} not found.");

      return Ok(response);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"An error occurred while retrieving the event: {ex.Message}");
    }
  }

  [HttpPost]
  public async Task<IActionResult> CreateEvent(EventModel model)
  {
    if (model == null)
      return BadRequest("Event model is null.");
    try
    {
      var result = await _eventService.Create(model);
      if (!result)
        return BadRequest("Failed to create event.");

      return Ok();
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"An error occurred while creating the event: {ex.Message}");
    }
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> RemoveEvent(string id)
  {
    if (string.IsNullOrEmpty(id))
      return BadRequest("Event ID is null or empty.");
    try
    {
      var result = await _eventService.Remove(id);
      if (!result)
        return NotFound("Event not found.");

      return Ok();
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"An error occurred while removing the event: {ex.Message}");
    }
  }
}
