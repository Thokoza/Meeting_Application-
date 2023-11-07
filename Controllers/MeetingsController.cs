using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeetingApp2.Data;
using MeetingApp2.Models;

namespace MeetingApp2.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly MeetingApp2Context _context;

        public MeetingsController(MeetingApp2Context context)
        {
            _context = context;
        }

        // GET: Meetings1
        public async Task<IActionResult> Index()
        {
            List<MeetingViewModel> meetings = (from m in await _context.Meetings.ToListAsync()
                                      join mi in _context.MeetingItems on m.MeetingsID equals mi.MeetingsID into x
                                      join t in _context.MeetingTypes on m.MeetingType equals t.MeetingTypeId
                                      select new MeetingViewModel
                                      {
                                          MeetingsID = m.MeetingsID,
                                          Date = m.Date,
                                          MeetingType = t.MeetingTypeName,
                                          MeetingItems = new List<ItemViewModel>()
                                          { 
                                           new  ItemViewModel(){
                                           Duration = x.Select(x=> x.Duration).FirstOrDefault(),
                                           Description = x.Select(x=> x.Description).FirstOrDefault(),
                                           PersonResponsible = x.Select(x=> x.PersonResponsible).FirstOrDefault(),
                                           MeetingItemStatus = x.Select(x=> x.MeetingItemStatus).FirstOrDefault()

                                           },
                                          }
                                      }).ToList();

            ViewBag.newMeetingList = meetings;
            return View(meetings);
        }

        // GET: Meetings1/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MeetingViewModel meetings = (from m in await _context.Meetings.ToListAsync()
                                               join mi in _context.MeetingItems on m.MeetingsID equals mi.MeetingsID into x
                                               join t in _context.MeetingTypes on m.MeetingType equals t.MeetingTypeId
                                               where m.MeetingsID == id
                                               select new MeetingViewModel
                                               {
                                                   MeetingsID = m.MeetingsID,
                                                   Date = m.Date,
                                                   MeetingType = t.MeetingTypeName,
                                                   MeetingItems = new List<ItemViewModel>()
                                          {
                                           new  ItemViewModel(){
                                           Duration = x.Select(x=> x.Duration).FirstOrDefault(),
                                           Description = x.Select(x=> x.Description).FirstOrDefault(),
                                           PersonResponsible = x.Select(x=> x.PersonResponsible).FirstOrDefault(),
                                           MeetingItemStatus = x.Select(x=> x.MeetingItemStatus).FirstOrDefault()

                                           },
                                          }
                                               }).FirstOrDefault();

            ViewBag.newMeetingList = meetings;

            if (meetings == null)
            {
                return NotFound();
            }

            return View(meetings);
        }

        // GET: Meetings1/Create
        public IActionResult Create()
        {
            var types = new List<SelectListItem>();
            var status = new List<SelectListItem>();
            var meetingtype = _context.MeetingTypes.ToList();
            var itemstatus = _context.MeetingItemStatuses.ToList();
            foreach (var m in meetingtype)
            {
                types.Add(new SelectListItem { Value = m.MeetingTypeId.ToString(), Text = m.MeetingTypeName });
            }
            foreach (var i in itemstatus)
            {
                status.Add(new SelectListItem { Value = i.MeetingItemStatusId.ToString(), Text = i.StatusDesc });
            }

            ViewBag.MeetingTypes = types;
            ViewBag.ItemStatus = status;
            return View();
        }

        // POST: Meetings1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeetingsID,Date,MeetingType")] Meeting meeting, List<MeetingItem> meetingItems)
        {
            //if (ModelState.IsValid)
            //{
                Guid id = Guid.NewGuid();

                foreach (var item in meetingItems)
                {
                    item.MeetingsID = id;
                }

                 _context.MeetingItems.AddRange(meetingItems);
               await _context.SaveChangesAsync();

                meeting.MeetingsID = id;
                _context.Add(meeting);
                await _context.SaveChangesAsync();

                //_context.Add(meeting);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            //}
            return View(meeting);
        }

        // GET: Meetings1/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }
            return View(meeting);
        }

        // POST: Meetings1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MeetingsID,Date,MeetingType")] Meeting meeting)
        {
            if (id != meeting.MeetingsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meeting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingExists(meeting.MeetingsID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(meeting);
        }

        // GET: Meetings1/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings
                .FirstOrDefaultAsync(m => m.MeetingsID == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // POST: Meetings1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var meeting = await _context.Meetings.FindAsync(id);
            _context.Meetings.Remove(meeting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingExists(Guid id)
        {
            return _context.Meetings.Any(e => e.MeetingsID == id);
        }
    }
}
