using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using MID_BCS240034.Models;

namespace MID_BCS240034.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // Create database if it does not exist
            context.Database.EnsureCreated();

            // If there are already categories, assume DB has been seeded
            if (context.EventCategories_BCS240034.Any())
            {
                return;   // DB has been seeded
            }

            // Seed categories
            var categories = new EventCategory_BCS240034[]
            {
                new EventCategory_BCS240034 { Name = "Music", Description = "Music and concerts" },
                new EventCategory_BCS240034 { Name = "Sports", Description = "Sporting events" },
                new EventCategory_BCS240034 { Name = "Conference", Description = "Conferences and talks" }
            };

            context.EventCategories_BCS240034.AddRange(categories);
            context.SaveChanges();

            // Seed events
            var events = new Event_BCS240034[]
            {
                new Event_BCS240034
                {
                    Name = "Summer Music Festival",
                    Price = 49.99m,
                    StartDate = DateTime.UtcNow.AddDays(14),
                    EndDate = DateTime.UtcNow.AddDays(15),
                    Location = "City Park",
                    Description = "An outdoor festival with multiple bands.",
                    EventCategoryId = categories[0].Id
                },
                new Event_BCS240034
                {
                    Name = "City Marathon",
                    Price = 0m,
                    StartDate = DateTime.UtcNow.AddDays(30),
                    EndDate = DateTime.UtcNow.AddDays(30),
                    Location = "Downtown",
                    Description = "Annual city marathon open to all.",
                    EventCategoryId = categories[1].Id
                },
                new Event_BCS240034
                {
                    Name = "Tech Conference 2026",
                    Price = 199.00m,
                    StartDate = DateTime.UtcNow.AddDays(60),
                    EndDate = DateTime.UtcNow.AddDays(62),
                    Location = "Convention Center",
                    Description = "A conference for developers and architects.",
                    EventCategoryId = categories[2].Id
                }
            };

            context.Events_BCS240034.AddRange(events);
            context.SaveChanges();

            // Seed images using provided images (3 uploaded images)
            var images = new EventImage_BCS240034[]
            {
                new EventImage_BCS240034 { ImageUrl = "/images/event1.jpg", IsThumbnail = true, EventId = events[0].Id },
                new EventImage_BCS240034 { ImageUrl = "/images/event2.jpg", IsThumbnail = false, EventId = events[0].Id },
                new EventImage_BCS240034 { ImageUrl = "/images/event3.jpg", IsThumbnail = false, EventId = events[0].Id }
            };

            context.EventImages_BCS240034.AddRange(images);
            context.SaveChanges();
        }
    }
}
