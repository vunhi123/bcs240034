using System.ComponentModel.DataAnnotations;

namespace MID_BCS240034.Models
{
    public class Event_BCS240034
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên không được để trống")]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string Location { get; set; }

        public string? Description { get; set; }

        [Required]
        public int EventCategoryId { get; set; }

        public EventCategory_BCS240034? EventCategory { get; set; }

        public ICollection<EventImage_BCS240034>? EventImages { get; set; }
    }
}
