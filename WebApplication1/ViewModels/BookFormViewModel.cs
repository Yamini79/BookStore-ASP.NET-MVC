using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BookStore.Models;
namespace BookStore.ViewModels
{
    public class BookFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Book Book { get; set; }
    }
}