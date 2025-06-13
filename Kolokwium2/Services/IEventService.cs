using Kolokwium2.DTOs;

namespace Kolokwium2.Services;

public interface IEventService
{
    Task<List<EventDetailsDto>> GetAllEventDetailsAsync();
    Task<UpdateEventResponseDto> UpdateEventAsync(int id, UpdateEventDto updateDto);
}