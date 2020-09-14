using LibraryMVC.Core.Contracts;
using LibraryMVC.Core.Models;
using LibraryMVC.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LibraryMVC.WebUI.Controllers
{
    public class FormatsController : Controller
    {
        // GET: Genres
        IRepository<Book> context;
        IRepository<BookFormat> bookFormats;

        public FormatsController(IRepository<Book> Context, IRepository<BookFormat> BookFormats)
        {
            context = Context;
            bookFormats = BookFormats;
        }

        public ActionResult Index(string Format = null)
        {
            List<Book> books;
            List<BookFormat> formats = bookFormats.Collection().ToList();

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
            model.BookFormats = formats;

            return View(model);
        }
    }
}