using System.ComponentModel.DataAnnotations;

namespace MID_BCS240034.Models
{
    public class EventCategory_BCS240034
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public ICollection<Event_BCS240034>? Events { get; set; }
    }
}
