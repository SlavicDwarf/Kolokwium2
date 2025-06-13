using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2.Models;

[Table("EventTags")]
public class EventTag
{
    public int EventId { get; set; }
    public int TagId { get; set; }
    [ForeignKey("EventId")]
    public Event Event { get; set; }
    [ForeignKey("TagId")]
    public Tag Tag { get; set; }
    
}