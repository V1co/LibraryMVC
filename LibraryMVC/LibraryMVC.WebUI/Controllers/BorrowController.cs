using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web.Security;
using LibraryMVC.DataAccess.SQL;
using LibraryMVC.Core.ViewModels;
using LibraryMVC.Core.Models;

namespace Library.Controllers
{
    public class BorrowController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult Index(string search = null)
        {
            var model = db.BorrowBook.ToList();
            List<BorrowedBooksViewModel> borrowedBooks = new List<BorrowedBooksViewModel>();
            foreach (var item in model)
            {
                Book book = db.Books.Find(item.BookId);
                BorrowedBooksViewModel borrowed = new BorrowedBooksViewModel();
                borrowed.BorrowedBookId = item.BorrowBookId;
                borrowed.BookId = item.BookId;
                borrowed.Title = book.Title;
                borrowed.UserName = item.UserName;
            }
            return View(borrowedBooks);
        }

        public ActionResult BorrowConfirmation(string id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var model = new BorrowBook();
            model.BookId = id;
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BorrowConfirmation(BorrowBook borrowBook)
        {
            borrowBook.UserName = User.Identity.GetUserName();

            Book book = db.Books.Find(borrowBook.BookId);
            book.NumberOfBooks--;
            db.Entry(book).State = EntityState.Modified;

            if (ModelState.IsValid)
            {
                db.BorrowBook.Add(borrowBook);
                db.SaveChanges();
                return RedirectToAction("Index", "Borrow");
            }

            return View(borrowBook);
        }
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BorrowBook borrowBook = db.BorrowBook.Find(id);
            if (borrowBook == null)
            {
                return HttpNotFound();
            }
            return View(borrowBook);
        }

        // POST: RentedBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BorrowBook borrowBook = db.BorrowBook.Find(id);
            Book book = db.Books.Find(borrowBook.BookId);
            book.NumberOfBooks++;

            db.BorrowBook.Remove(borrowBook);
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
