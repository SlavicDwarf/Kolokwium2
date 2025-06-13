namespace Kolokwium2.DTOs;

public class UpdateEventDto
{
 public string Title { get; set; }
 public string Description { get; set; }
 public DateTime Date { get; set; }
 public List<int> TagIds { get; set; } = new List<int>();
 public List<int> ParticipantIds { get; set; } = new List<int>();
}