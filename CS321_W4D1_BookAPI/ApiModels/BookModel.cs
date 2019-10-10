﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CS321_W4D1_BookAPI.ApiModels
{
    public class BookModel
    {
        public int Id { get; set; }
        // TODO: fill in BookModel properties
        public string Title { get; set; }
        public string OriginalLanguage { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }

        public int AuthorId { get; set; }
        public string Author { get; set; } // string containing the author's full name

        public int PublisherId { get; set; }
    }
}
