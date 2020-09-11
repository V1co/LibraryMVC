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
            IEnumerable<Book> bookTitles = context.Collection().ToList();
            IEnumerable<Book> bookAuthors = context.Collection().ToList();

            if (!String.IsNullOrEmpty(searching))
            {
                bookTitles = bookTitles.Where(a => a.Title.ToLower().Contains(searching.ToLower()));
            }

            if (!String.IsNullOrEmpty(searching))
            {
                bookAuthors = bookAuthors.Where(a => a.WriterLastName.ToLower().Contains(searching.ToLower()));
            }

            ViewBag.SearchTerm = searching;
            var model = new List<Book>();

            foreach(var item in bookTitles)
            {
                model.Add(item);
            }

            foreach (var item in bookAuthors)
            {
                model.Add(item);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Borrow(string CustomerId, string Id)
        {
            if (CustomerId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(CustomerId);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var Results = from b in db.Books
                          select new
                          {
                              b.Id,
                              b.Title,
                              Borrowed = ((from cb in db.CustomersToBooks
                                           where (cb.CustomerId == CustomerId) & (cb.BookId == b.Id)
                                           select cb).Count() > 0)
                          };
            var CustomersViewModel = new CustomersViewModel();

            CustomersViewModel.CustomerId = CustomerId;
            CustomersViewModel.CustomerFirstName = customer.FirstName;
            CustomersViewModel.CustomerName = customer.LastName;

            var BorrowedBooks = new List<BorrowedBooksViewModel>();

            foreach (var item in Results)
            {
                BorrowedBooks.Add(new BorrowedBooksViewModel { Id = item.Id, Name = item.Title, Borrowed = item.Borrowed });
                db.Books.Find(Id).NumberOfBorrows++;
            }

            CustomersViewModel.BorrowedBooks = BorrowedBooks;

            return View(CustomersViewModel);
        }
    }
}