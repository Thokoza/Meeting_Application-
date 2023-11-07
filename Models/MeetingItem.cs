using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApp2.Models
{
    public class MeetingItem
    {
        [Key]
        public int MeetingItemId { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string PersonResponsible { get; set; }
        public int MeetingItemStatus { get; set; }
        public Guid MeetingsID { get; set; }
        public Meeting Meeting { get; set; }
        public  MeetingItemStatus MeetingItemStatuses { get; set; }
    }
}
