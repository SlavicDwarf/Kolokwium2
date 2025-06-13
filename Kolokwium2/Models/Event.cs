using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2.Models;

[Table("Events")]
public class Event
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(150)]
    public string Title { get; set; }
    [Required]
    [MaxLength(500)]
    public string Description { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public int OrganizerId { get; set; }
    [ForeignKey("OrganizerId")]
    public User Organizer { get; set; }

    public ICollection<EventTag> EventTags { get; set; } = new List<EventTag>();
    public ICollection<EventParticipant> EventParticipants { get; set; } = new List<EventParticipant>();

}