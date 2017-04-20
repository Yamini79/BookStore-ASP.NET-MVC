using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using WebApplication1.Models;
using System.Data.Entity;
using BookStore.ViewModels;

namespace WebApplication1.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();


        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            return Content("Welcome");
        }
        //List Of Books
        public ActionResult BooksList()
        {
            var books = _context.Books.Include(b => b.Genre).ToList();
            return View(books);
        }
        /*public List<Book> GetBooks()
        {
            var li = new List<Book>
            {
                new Book {id=1, bname="ABC" },
                new Book {id=2, bname="DEF" }
            };
            return li;
        }**/
       public ActionResult Details(int id)
        {
            var det = _context.Books.Include(c => c.Genre).ToList();
            foreach(var i in det)
            {
                if (i.id == id)
                {
                    return View(i);
                }
               
            }
            return Content("Book Not found");

        }
        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.id == id);

            if (book == null)
                return HttpNotFound();
            var viewModel = new BookFormViewModel
            {
                Book = book,
                Genres = _context.Genres.ToList()
            };
            return View("BookForm", viewModel);
        }
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new BookFormViewModel
            {
                Genres = genres
            };
            return View("BookForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Book book)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new BookFormViewModel
                {
                    Book = book,
                    Genres = _context.Genres.ToList()
                };
                return View("BookForm", viewModel);
            }
            if (book.id == 0)
                _context.Books.Add(book);
            else
            {
                var BooksInDb = _context.Books.Single(g => g.id == book.id);
                BooksInDb.id = book.id;
                BooksInDb.bname = book.bname;
                BooksInDb.GenreId = book.GenreId;
                BooksInDb.ReleaseDate = book.ReleaseDate;
                BooksInDb.AvailCopies = book.AvailCopies;
            }
            _context.SaveChanges();
            return RedirectToAction("BooksList", "Books");
        }
    }
}