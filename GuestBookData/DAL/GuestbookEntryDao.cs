using GuestbookData.Model;
using System.Collections.Generic;
using System.Linq;

namespace GuestbookData.DAL
{
    public class GuestbookEntryDao : IGuestbookEntryDao
    {
        public void AddEntry(GuestbookEntry guestbookEntry)
        {
            using var context = new GuestbookDbContext();
            context.GuestbookEntries.Add(guestbookEntry);
            context.SaveChanges();
        }

        public int CountEntries()
        {
            using var context = new GuestbookDbContext();
            return context.GuestbookEntries.Count();
        }

        public IEnumerable<GuestbookEntry> GetEntries(int start, int count)
        {
            using var context = new GuestbookDbContext();
            return context.GuestbookEntries.OrderByDescending(e => e.Timestamp).Skip(start).Take(count);
        }
    }
}
