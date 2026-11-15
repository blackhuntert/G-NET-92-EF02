using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Entityes
{
    [Table("Eventorganizers")]
    internal class Organizer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(150)]
        public string? CompanyName { get; set; }
        public bool IsVerified { get; set; }

        public OrganizerProfile? profile { get; set; }
        public ICollection<Event>? Events { get; set; } = new List<Event>();
    }
}
