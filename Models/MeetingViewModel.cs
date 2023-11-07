using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApp2.Models
{
    public class MeetingViewModel
    {
        public Guid MeetingsID { get; set; }
        public DateTime Date { get; set; }
        public string MeetingType { get; set; }
        public MeetingType MeetingTypes { get; set; }
        //public int MeetingItem { get; set; }
        public virtual IList<ItemViewModel> MeetingItems { get; set; }
    }
}
