using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Kolokwium2.Data;
using Kolokwium2.DTOs;
using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Services;

public class EventService : IEventService
{
    private readonly EventsDbContext _context;

    public EventService(EventsDbContext context)
    {
        _context = context;
    }

    public async Task<List<EventDetailsDto>> GetAllEventsDetailsAsync()
    {
        var events = await _context.Events
            .Include(e => e.Organizer)
            .Include(e => e.EventTags)
            .ThenInclude(et => et.Tag)
            .Include(e => e.EventParticipants)
            .ThenInclude(ep => ep.User)
            .ToListAsync();
        var result = events.Select(e => EventDetailsDto
        {
            Id = e.Id,
            Title = e.Title,
            Description = e.Desciption,
            Date = e.Date,
            Organizer = new UserDto
            {
                Id = e.Organizer.Id,
                Username = e.Organizer.Username
            },
            Participans = e.EventParticipants.Select(ep => new UserDto
            {
                Id = ep.User.Id,
                Username = ep.User.Username
            }).ToList(),
            Tags = e.EventTags.Select(et = new TagDto
            {
                Id = et.Tag.Id,
                Name = et.Tag.Name
            }).ToList()
        }).ToList();
        return result;
    }
        public async Task<UpdateEventResponseDto> UpdateEventAsync(int id, UpdateEventDto updateDto)
        {var eventToUpdate = await _context.Events
            .Include(e => e.EventTags)
            .Include(e => e.EventParticipants)
            .FirstOrDefalutAsync(e => e.Id == id);
            if (eventToUpdate == null)
            {
                return null;
            }
            eventToUpdate.Title = updateDto.Title;
            eventToUpdate.Description = updateDto.Description;
            eventToUpdate.Date = updateDto.Date;

            _context.EventTags.RemoveRange(eventToUpdate.EventTags);
            foreach (var tagId in updateDto.TagIds)
            {
                eventToUpdate.EventTags.Add(new EventTag
                {
                    EventId = id,
                    TagId = tagId
                });
            }

            _context.EventParticipants.RemoveRange(eventToUpdate.EventParticipans);
            foreach (var participantId in updateDto.ParticipantIds)
            {
                eventToUpdate.EventParticipans.Add(new EventParticipant
                {
                    EventId = id,
                    UserId = participantId
                });
            }

            await _context.SaveChangesAsync();
            return new UpdateEventResponseDto
            {
                Message = "Zaktualizowano",
                EventId = id
                UpdatedTags = updateDto.TagIds,
                UpdatedParticipants = updateDto.ParticipantIds
            };
        }
}