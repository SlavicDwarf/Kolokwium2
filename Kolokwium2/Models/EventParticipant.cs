using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2.Models;

[Table("EventParticipants")]
public class EventParticipant
{
    public int EventId { get; set; }
    public int UserId { get; set; }
    [ForeignKey("EventId")]
    public Event Event { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
    
}