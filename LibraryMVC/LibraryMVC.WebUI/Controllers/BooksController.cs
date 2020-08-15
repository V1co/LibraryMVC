using LibraryMVC.Core.Contracts;
using LibraryMVC.Core.Models;
using LibraryMVC.Core.ViewModels;
using LibraryMVC.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public ActionResult All()
        {
            List<Book> books;

            BookListViewModel model = new BookListViewModel();
            books = context.Collection().ToList();
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

        public ActionResult Available()
        {
            List<Book> books;

            BookListViewModel model = new BookListViewModel();
            books = context.Collection().ToList();
            model.Books = books;

            return View(model);
        }
    }
}