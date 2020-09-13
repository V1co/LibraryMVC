using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryMVC.Core.Models;
using LibraryMVC.Core.ViewModels;
using LibraryMVC.DataAccess.SQL;

namespace LibraryMVC.WebUI.Controllers
{
    [Authorize(Users = "admin@library.com")]
    public class CustomersController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
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
                                           where (cb.CustomerId == id) & (cb.BookId == b.Id)
                                           select cb).Count() > 0)
                          };
            var CustomersViewModel = new CustomersViewModel();

            CustomersViewModel.CustomerId = id;
            CustomersViewModel.CustomerFirstName = customer.FirstName;
            CustomersViewModel.CustomerName = customer.LastName;

            var BorrowedBooks = new List<BorrowedBooksViewModel>();

            foreach (var item in Results)
            {
                BorrowedBooks.Add(new BorrowedBooksViewModel { Id = item.Id, Name = item.Title, Borrowed = item.Borrowed });
            }

            CustomersViewModel.BorrowedBooks = BorrowedBooks;

            return View(CustomersViewModel);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
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
                                          where (cb.CustomerId == id) & (cb.BookId == b.Id)
                                          select cb).Count() > 0)
                          };
            var CustomersViewModel = new CustomersViewModel();

            CustomersViewModel.CustomerId = id;
            CustomersViewModel.CustomerFirstName = customer.FirstName;
            CustomersViewModel.CustomerName = customer.LastName;

            var BorrowedBooks = new List<BorrowedBooksViewModel>();

            foreach (var item in Results)
            {
                BorrowedBooks.Add(new BorrowedBooksViewModel { Id = item.Id, Name = item.Title, Borrowed = item.Borrowed });
            }

            CustomersViewModel.BorrowedBooks = BorrowedBooks;

            return View(CustomersViewModel);
        }

        // POST: Customers/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomersViewModel customer)
        {
            if (ModelState.IsValid)
            {
                var MyCustomer = db.Customers.Find(customer.CustomerId);

                MyCustomer.FirstName = customer.CustomerFirstName;
                MyCustomer.LastName = customer.CustomerName;

                foreach (var item in db.CustomersToBooks)
                {
                    if (item.CustomerId == customer.CustomerId)
                    {
                        db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                }

                foreach (var item in customer.BorrowedBooks)
                {
                    if (item.Borrowed)
                    {
                        db.CustomersToBooks.Add(new CustomerToBook() { CustomerId = customer.CustomerId, BookId = item.Id });
                        db.Books.Find(item.Id).NumberOfBorrows++;
                    }
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
