using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApp2.Models
{
    public class MeetingItemStatus
    {
        [Key]
        public int MeetingItemStatusId { get; set; }
        public string StatusDesc { get; set; }
    }
}
