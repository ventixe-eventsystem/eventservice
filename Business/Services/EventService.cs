﻿using Business.Interfaces;
using Business.Models;
using Data.Entites;
using Data.Interfaces;

namespace Business.Services;
public class EventService(IEventRepository repository) : IEventService
{
  private readonly IEventRepository _repository = repository;

  public async Task<bool> Create(EventModel model)
  {
    var entity = new EventEntity
    {
      Name = model.Name,
      Location = model.Location,
      Description = model.Description,
      DateAndTime = model.DateAndTime,
      MaxAttendees = model.MaxAttendees > 0 ? model.MaxAttendees : 0
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
      DateAndTime = e.DateAndTime,
      MaxAttendees = e.MaxAttendees
    });

    return allEvents;
  }

  public async Task<EventModel> GetEventByIdAsync(string id)
  {
    var entity = await _repository.GetByIdAsync(id) ?? throw new Exception("Event not found");

    var model = new EventModel
    {
      Id = entity.Id,
      Name = entity.Name,
      Location = entity.Location,
      Description = entity.Description,
      DateAndTime = entity.DateAndTime,
      MaxAttendees = entity.MaxAttendees > 0 ? entity.MaxAttendees : 0
    };
    return model;
  }

  public async Task<bool> Remove(string id)
  {
    if (string.IsNullOrEmpty(id))
      throw new ArgumentException("Id cannot be null or empty", nameof(id));
    var result = await _repository.Delete(id);
    return result > 0;
  }
}
