using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        public int id { get; set; }

        [Display(Name = "Name")]
        public string bname { get; set; }

        public string author { get; set; }

        public float? price { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Display(Name = "Number in Stock")]
        public int AvailCopies { get; set; }

    }
}