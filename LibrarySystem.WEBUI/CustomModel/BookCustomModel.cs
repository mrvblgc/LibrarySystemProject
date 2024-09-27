using LibrarySystem.Entity.Model;

namespace LibrarySystem.WEBUI.CustomModel
{
    public class BookCustomModel
    {
        public int BookId { get; set; }

        public string BookName { get; set; } = null!;

        public decimal BookPrice { get; set; }

        public int? BookPage { get; set; }
    }
}
