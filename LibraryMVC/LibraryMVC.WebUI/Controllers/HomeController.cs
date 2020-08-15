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
    public class HomeController : Controller
    {

        IRepository<Book> context;
        IRepository<BookFormat> bookFormats;
        IRepository<BookGenre> bookGenres;

        public HomeController(IRepository<Book> Context, IRepository<BookFormat> BookFormats, IRepository<BookGenre> BookGenres)
        {
            context = Context;
            bookFormats = BookFormats;
            bookGenres = BookGenres;
        }

        public ActionResult Index(string Genre = null, string Format = null)
        {
            List<Book> books;
            List<BookGenre> genres = bookGenres.Collection().ToList();
            List<BookFormat> formats = bookFormats.Collection().ToList();

            if (Genre == null)
            {
                books = context.Collection().ToList();
            }
            else
            {
                books = context.Collection().Where(b => b.Genre == Genre).ToList();
            }

            if (Format == null)
            {
                books = context.Collection().ToList();
            }
            else
            {
                books = context.Collection().Where(b => b.Format == Format).ToList();
            }

            BookListViewModel model = new BookListViewModel();
            model.Books = books;
            model.BookGenres = genres;
            model.BookFormats = formats;

            return View(model);
        }

        public ActionResult Details(string Id)
        {
            Book book = context.Find(Id);

            if (book != null)
            {
                return View(book);
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}