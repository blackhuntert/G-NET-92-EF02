using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Entityes
{
    public enum BadgeTier
    {
        stander = 1,
        VIP = 2,
    }
    internal class Badge
    {
        public int Id { get; set; }
        public string BadgeNumber { get; set; } = null!; 
        public DateTime IssuedDate { get; set; } 
        public BadgeTier Tier { get; set; }

        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; } = null!;
    }
}
