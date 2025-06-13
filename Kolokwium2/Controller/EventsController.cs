using Kolokwium2.DTOs;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controller;

[ApiController]
[Route("api/[controller]")]
public class EventsController:ControllerBase
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet("details")]
    public async Task<ActionResult<List<EventDetailsDto>>> GetEventDetails()
    {
        try
        {
            var events = await _eventService.GetAllEventsDetailsAsync();
            return Ok(events);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateEventResponseDto>> UpdateEvent(int id, [FromBody] UpdateEventDto updateDto)
    {
        try
        {
            var result=await _eventService.UpdateEventAsync(id, updateDto);
            if (result == null)
            {
                return NotFound("Nie znaleziono");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }
}