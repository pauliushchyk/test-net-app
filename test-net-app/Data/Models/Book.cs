using System.Collections.Generic;

namespace testnetapp.Data.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<BookTag> BookTags { get; set; }
    }
}
