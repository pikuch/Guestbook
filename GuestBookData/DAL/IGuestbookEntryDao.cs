using GuestbookData.Model;
using System.Collections.Generic;

namespace GuestbookData.DAL
{
    public interface IGuestbookEntryDao
    {
        void AddEntry(GuestbookEntry guestbookEntry);
        int CountEntries();
        IEnumerable<GuestbookEntry> GetEntries(int start, int count);
    }
}