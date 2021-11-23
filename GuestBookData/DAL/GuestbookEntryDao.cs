using GuestbookData.Model;
using System.Collections.Generic;
using System.Linq;

namespace GuestbookData.DAL
{
    public class GuestbookEntryDao : IGuestbookEntryDao
    {
        private readonly GuestbookDbContext _context;
        public GuestbookEntryDao(GuestbookDbContext context)
        {
            _context = context;
        }
        public void AddEntry(GuestbookEntry guestbookEntry)
        {
            _context.GuestbookEntries.Add(guestbookEntry);
            _context.SaveChanges();
        }

        public int CountEntries()
        {
            return _context.GuestbookEntries.Count();
        }

        public IEnumerable<GuestbookEntry> GetEntries(int start, int count)
        {
            return _context.GuestbookEntries.OrderByDescending(e => e.Timestamp).Skip(start).Take(count).ToList();
        }
    }
}
