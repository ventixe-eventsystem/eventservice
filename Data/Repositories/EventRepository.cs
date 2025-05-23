﻿using Data.Contexts;
using Data.Entites;
using Data.Interfaces;

namespace Data.Repositories;
public class EventRepository(DataContext context) : BaseRepository<EventEntity>(context), IEventRepository
{
}
