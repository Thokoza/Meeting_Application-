using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApp2.Models
{
    public class MeetingType
    {
        [Key]
        public int MeetingTypeId { get; set; }
        public string MeetingTypeName { get; set; }
    }
}
