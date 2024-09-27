namespace LibrarySystem.DTO.DTOS.BookDTOS
{
    public class BookAuthorExcelDto
    {
        public string AuthorName { get; set; } = null!;
        public string AuthorSurname { get; set; } = null!;
        public string BookName { get; set; } = null!;
        public string PublishingHouseName { get; set; } = null!;
        public int BooPrice { get; set; }
    }
}
