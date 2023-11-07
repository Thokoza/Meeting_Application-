using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApp2.Models
{
    public class Meeting
    {
        [Key]
        public Guid MeetingsID { get; set; }
        public DateTime Date { get; set; }
        public int MeetingType { get; set; }
        public MeetingType MeetingTypes { get; set; }
        //public int MeetingItem { get; set; }
        public virtual IList<MeetingItem> MeetingItems { get; set; }
    }
}
