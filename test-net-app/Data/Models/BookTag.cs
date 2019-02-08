namespace testnetapp.Data.Models
{
    public class BookTag
    {
        public Book Book { get; set; }

        public int BookId { get; set; }

        public Tag Tag { get; set; }

        public int TagId { get; set; }
    }
}
