using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Kolokwium2.Models;

[Table("Tags")]
public class Tag
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    public ICollection<EventTag> EventTags { get; set; } = new List <EventTag>();
}