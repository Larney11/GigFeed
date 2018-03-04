using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GigFeed.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public bool IsCanceled { get; private set; }

        public ApplicationUser Artist { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }

        // private because you should not be able to overwite a collection.
        public ICollection<Attendance> Attendances { get; private set; }

        public Gig()
        {
            Attendances = new Collection<Attendance>();
        }

        // Cancel a gig
        public void Cancel()
        {
            IsCanceled = true;

            var notification = Notification.GigCanceled(this);

            // Send notification to all attendees
            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

        // Update a gig
        public void Modify(string venue, DateTime datetime, byte genre)
        {
            var notification = Notification.GigUpdated(this, DateTime, Venue);

            Venue = venue;
            DateTime = datetime;
            GenreId = genre;

            // Send notification to all attendees
            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }
    }
}