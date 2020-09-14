using LibraryMVC.Core.Contracts;
using LibraryMVC.Core.Models;
using LibraryMVC.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LibraryMVC.WebUI.Controllers
{
    public class BooksController : Controller
    {
        // GET: BookFormatManager
        IRepository<Book> context;
        IRepository<BookFormat> bookFormats;
        IRepository<BookGenre> bookGenres;

        public BooksController(IRepository<Book> Context, IRepository<BookFormat> BookFormats, IRepository<BookGenre> BookGenres)
        {
            context = Context;
            bookFormats = BookFormats;
            bookGenres = BookGenres;
        }

        public ActionResult All(string sorting)
        {
            IEnumerable<Book> books = context.Collection().ToList();

            switch (sorting)
            {
                case "titleAscending":
                    books = books.OrderBy(a => a.Title);
                    break;
                case "titleDescending":
                    books = books.OrderByDescending(a => a.Title);
                    break;
                case "writerAscending":
                    books = books.OrderBy(a => a.WriterLastName);
                    break;
                case "writerDescending":
                    books = books.OrderByDescending(a => a.WriterLastName);
                    break;
                default:
                    books = books.OrderBy(a => a.Title);
                    break;
            }
            BookListViewModel model = new BookListViewModel();
            model.Books = books;

            return View(model);
        }

        public ActionResult New()
        {
            List<Book> books;

            BookListViewModel model = new BookListViewModel();
            books = context.Collection().ToList();
            model.Books = books;

            return View(model);
        }

        public ActionResult Recommended()
        {
            List<Book> books;

            BookListViewModel model = new BookListViewModel();
            books = context.Collection().ToList();
            model.Books = books;

            return View(model);
        }

        public ActionResult Available(string sorting)
        {
            IEnumerable<Book> books = context.Collection().ToList();

            switch (sorting)
            {
                case "titleAscending":
                    books = books.OrderBy(a => a.Title);
                    break;
                case "titleDescending":
                    books = books.OrderByDescending(a => a.Title);
                    break;
                case "writerAscending":
                    books = books.OrderBy(a => a.WriterLastName);
                    break;
                case "writerDescending":
                    books = books.OrderByDescending(a => a.WriterLastName);
                    break;
                default:
                    books = books.OrderBy(a => a.Title);
                    break;
            }
            BookListViewModel model = new BookListViewModel();
            model.Books = books;

            return View(model);
        }
    }
}