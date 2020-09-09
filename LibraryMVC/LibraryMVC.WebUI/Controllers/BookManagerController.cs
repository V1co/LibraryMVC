using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVC.Core;
using LibraryMVC.Core.Contracts;
using LibraryMVC.Core.Models;
using LibraryMVC.Core.ViewModels;
using LibraryMVC.DataAccess.InMemory;

namespace LibraryMVC.WebUI.Controllers
{
    [Authorize(Users = "admin@library.com")]
    public class BookManagerController : Controller
    {
        // GET: BookManager
        
        IRepository<Book> context;
        IRepository<BookFormat> bookFormats;
        IRepository<BookGenre> bookGenres;

        public BookManagerController(IRepository<Book> Context, IRepository<BookFormat> BookFormats, IRepository<BookGenre> BookGenres)
        {
            context = Context;
            bookFormats = BookFormats;
            bookGenres = BookGenres;
        }
        public ActionResult Index()
        {
            List<Book> books = context.Collection().ToList();
            return View(books);
        }

        public ActionResult Create()
        {
            BookManagerViewModel viewModel = new BookManagerViewModel();
            viewModel.Book = new Book();
            viewModel.Formats = bookFormats.Collection();
            viewModel.Genres = bookGenres.Collection(); 
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Book book, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            else
            {

                if (file != null)
                {
                    book.Image = book.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//BookImages//") + book.Image);
                }

                context.Insert(book);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Book book = context.Find(Id);

            if (book == null)
            {
                return HttpNotFound();
            }
            else
            {
                BookManagerViewModel viewModel = new BookManagerViewModel();
                viewModel.Book = book;
                viewModel.Formats = bookFormats.Collection();
                viewModel.Genres = bookGenres.Collection();
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Book book, string Id, HttpPostedFileBase file)
        {
            Book bookToEdit = context.Find(Id);
            if (book == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(book);
                }

                if (file != null)
                {
                    bookToEdit.Image = book.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//BookImages//") + bookToEdit.Image);
                }

                bookToEdit.Title = book.Title;
                bookToEdit.WriterFirstName = book.WriterFirstName;
                bookToEdit.WriterLastName = book.WriterLastName;
                bookToEdit.ReleaseDate = book.ReleaseDate;
                bookToEdit.Publisher = book.Publisher;
                bookToEdit.Genre = book.Genre;
                bookToEdit.Format = book.Format;
                bookToEdit.Description = book.Description;

                context.Commit();

                return RedirectToAction("Index");
            }
        }
        
        public ActionResult Delete(string Id)
        {
            Book bookToDelete = context.Find(Id);

            if (bookToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(bookToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Book bookToDelete = context.Find(Id);

            if (bookToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}