﻿namespace BookApi.Models
{
    public class AddBookDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
