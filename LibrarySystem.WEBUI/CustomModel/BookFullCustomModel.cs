namespace LibrarySystem.WEBUI.CustomModel
{
    public class BookFullCustomModel
    {
        public int BookId { get; set; }

        public string BookName { get; set; } = null!;

        public decimal BookPrice { get; set; }

        public int? BookPage { get; set; }

        public int PublishingHouseId { get; set; }

        public int AuthorId { get; set; }
    }
}
