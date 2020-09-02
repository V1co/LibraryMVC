  
using LibraryMVC.Core.Contracts;
using LibraryMVC.Core.Models;
using LibraryMVC.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using LibraryMVC.WebUI.Models;
using LibraryMVC.DataAccess.SQL;
using System.Net;
using System.Data.Entity;

namespace LibraryMVC.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db = new DataContext();

        IRepository<Book> context;
        IRepository<BookFormat> bookFormats;
        IRepository<BookGenre> bookGenres;
        IRepository<Customer> customerContext;
        CustomersViewModel customers = new CustomersViewModel();

        public HomeController(IRepository<Book> Context, IRepository<BookFormat> BookFormats, IRepository<BookGenre> BookGenres, IRepository<Customer> CustomerContext)
        {
            context = Context;
            bookFormats = BookFormats;
            bookGenres = BookGenres;
            customerContext = CustomerContext;
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

        public ActionResult Search(string searching)
        {
            IEnumerable<Book> books = context.Collection().ToList();

            if (!String.IsNullOrEmpty(searching))
            {
                books = books.Where(a => a.Title.ToLower().Contains(searching.ToLower()));
            }

            ViewBag.SearchTerm = searching;

            return View(books.ToList());
        }

        public ActionResult Borrow(string id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var model = new CustomerToBook();
            model.BookId = id;

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Borrow(CustomerToBook borrowedBook)
        {
            borrowedBook.Customer = User.Identity.GetUserName();

            Book book = db.Books.Find(borrowedBook.Book);
            book.NumberOfBooks--;
            db.Entry(book).State = EntityState.Modified;

            if (ModelState.IsValid)
            {
                db.CustomersToBooks.Add(borrowedBook);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(borrowedBook);
        }
    }
}