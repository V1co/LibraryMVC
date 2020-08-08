using LibraryMVC.Core.Models;
using LibraryMVC.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMVC.WebUI.Controllers
{
    public class BookFormatManagerController : Controller
    {
        // GET: BookFormatManager
        InMemoryRepository<BookFormat> context;

        public BookFormatManagerController()
        {
            context = new InMemoryRepository<BookFormat>();
        }
        public ActionResult Index()
        {
            List<BookFormat> booksFormats = context.Collection().ToList();
            return View(booksFormats);
        }

        public ActionResult Create()
        {
            BookFormat bookFormat = new BookFormat();
            return View(bookFormat);
        }

        [HttpPost]
        public ActionResult Create(BookFormat bookFormat)
        {
            if (!ModelState.IsValid)
            {
                return View(bookFormat);
            }
            else
            {
                context.Insert(bookFormat);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            BookFormat bookFormat = context.Find(Id);

            if (bookFormat == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(bookFormat);
            }
        }

        [HttpPost]
        public ActionResult Edit(BookFormat bookFormat, string Id)
        {
            BookFormat bookFormatToEdit = context.Find(Id);
            if (bookFormat == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(bookFormat);
                }

                bookFormatToEdit.Format = bookFormat.Format;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            BookFormat bookFormatToDelete = context.Find(Id);

            if (bookFormatToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(bookFormatToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            BookFormat bookFormatToDelete = context.Find(Id);

            if (bookFormatToDelete == null)
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