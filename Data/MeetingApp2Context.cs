using MeetingApp2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApp2.Data
{
    public class MeetingApp2Context : DbContext
    {
        public MeetingApp2Context(DbContextOptions<MeetingApp2Context> options): base(options)
        {
        }

        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingType> MeetingTypes { get; set; }
        public DbSet<MeetingItem> MeetingItems { get; set; }
        public DbSet<MeetingItemStatus> MeetingItemStatuses { get; set; }
    }
}
