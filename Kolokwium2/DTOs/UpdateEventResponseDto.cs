namespace Kolokwium2.DTOs;

public class UpdateEventResponseDto
{
    public string Message { get; set; }
    public int EventId { get; set; }
    public List<int> UpdatedTags { get; set; }
    public List<int> UpdatedParticipants { get; set; }
}