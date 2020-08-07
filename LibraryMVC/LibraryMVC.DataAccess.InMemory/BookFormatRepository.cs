using LibraryMVC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.DataAccess.InMemory
{
    public class BookFormatRepository
    {
        ObjectCache cache = MemoryCache.Default;

        List<BookFormat> bookFormats;

        public BookFormatRepository()
        {
            bookFormats = cache["bookFormats"] as List<BookFormat>;

            if (bookFormats == null)
            {
                bookFormats = new List<BookFormat>();
            }
        }

        public void Commit()
        {
            cache["bookFormats"] = bookFormats;
        }

        public void Insert(BookFormat bookFormat)
        {
            bookFormats.Add(bookFormat);
        }

        public void Update(BookFormat bookFormat)
        {
            BookFormat bookFormatToUpdate = bookFormats.Find(b => b.Id == bookFormat.Id);

            if (bookFormatToUpdate != null)
            {
                bookFormatToUpdate = bookFormat;
            }
            else
            {
                throw new Exception("Book format not found");
            }
        }

        public BookFormat Find(string Id)
        {
            BookFormat bookFormat = bookFormats.Find(b => b.Id == Id);

            if (bookFormat != null)
            {
                return bookFormat;
            }
            else
            {
                throw new Exception("Book format not found");
            }
        }

        public IQueryable<BookFormat> Collection()
        {
            return bookFormats.AsQueryable();
        }

        public void Delete(string Id)
        {
            BookFormat bookFormatToDelete = bookFormats.Find(b => b.Id == Id);

            if (bookFormatToDelete != null)
            {
                bookFormats.Remove(bookFormatToDelete);
            }
            else
            {
                throw new Exception("Book format not found");
            }
        }
    }
}
