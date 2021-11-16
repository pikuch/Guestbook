using System.Collections.Generic;

namespace Guestbook.ViewModels
{
    public class IndexViewModel
    {
        public List<Entry> entries { get; set; }
        public int currentPage;
        public int pageCount;
    }
}
