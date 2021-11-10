using System;

namespace GuestbookData.Model
{
    public class GuestbookEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
