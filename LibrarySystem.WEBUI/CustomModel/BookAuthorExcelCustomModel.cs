﻿namespace LibrarySystem.WEBUI.CustomModel
{
    public class BookAuthorExcelCustomModel
    {
        public string AuthorName { get; set; } = null!;
        public string AuthorSurname { get; set; } = null!;
        public string BookName { get; set; } = null!;
        public string PublishingHouseName { get; set; } = null!;
        public int BookPrice { get; set; }
    }
}
