namespace Kolokwium2.DTOs;

public class EventDetailsDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public UserDto Organizer { get; set; }
    public List<UserDto> Participants { get; set; } = new List<UserDto>();
    public List<TagDto> Tags { get; set; } = new List<TagDto>();
}