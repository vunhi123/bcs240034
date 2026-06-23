namespace MID_BCS240034.Models
{
    public class EventImage_BCS240034
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public bool IsThumbnail { get; set; }

        public int EventId { get; set; }

        public Event_BCS240034? Event { get; set; }
    }
}
