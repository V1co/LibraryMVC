using LibraryMVC.Core.Contracts;
using LibraryMVC.Core.Models;
using LibraryMVC.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMVC.WebUI.Controllers
{
    public class GenresController : Controller
    {
        // GET: Genres
        IRepository<Book> context;
        IRepository<BookGenre> bookGenres;

        public GenresController(IRepository<Book> Context, IRepository<BookFormat> BookFormats, IRepository<BookGenre> BookGenres)
        {
            context = Context;
            bookGenres = BookGenres;
        }

        public ActionResult Index(string Genre = null)
        {
            List<Book> books;
            List<BookGenre> genres = bookGenres.Collection().ToList();

            if (Genre == null)
            {
                books = context.Collection().ToList();
            }
            else
            {
                books = context.Collection().Where(b => b.Genre == Genre).ToList();
            }

            BookListViewModel model = new BookListViewModel();
            model.Books = books;
            model.BookGenres = genres;

            return View(model);
        }
    }
}