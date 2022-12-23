using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WizLib_DataAccess.Data;
using WizLib_Models.Models;
using WizLib_Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace WizLib.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //Eager loading better than explicit loading
            List<Book> objList = _db.Books.Include(u => u.Publisher).ToList();

            //foreach(var obj in objList)
            //{
                //least efficient
                // obj.Publisher = _db.Publishers.FirstOrDefault(g => g.Publisher_Id == obj.Publisher_Id);

                //Explicit loading more efficient
               // _db.Entry(obj).Reference(u => u.Publisher).Load();
            //}
            return View(objList);
        }

        public IActionResult Details(int? id)
        {
            BookVM obj = new BookVM();

            if (id == null)
            {
                return View(obj);
            }
            //this for edit
            //Eager loading
            obj.Book = _db.Books.Include(u => u.BookDetail).FirstOrDefault(u => u.Book_Id == id);
            //obj.Book = _db.Books.FirstOrDefault(u => u.Book_Id == id);
            //obj.Book.BookDetail = _db.BookDetails.FirstOrDefault(i => i.BookDetail_Id == obj.Book.BookDetail_Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(BookVM obj)
        {
            if (obj.Book.BookDetail.BookDetail_Id == 0)
            {
                //this is create
                _db.BookDetails.Add(obj.Book.BookDetail);
                _db.SaveChanges();

                var BookFromDB = _db.Books.FirstOrDefault(i => i.BookDetail_Id == obj.Book.BookDetail_Id);
                BookFromDB.BookDetail_Id = obj.Book.BookDetail.BookDetail_Id;
                _db.SaveChanges();
            }
            else
            {
                //this is update
                _db.BookDetails.Update(obj.Book.BookDetail); 
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));

        }



        public IActionResult Upsert(int? id)
        {
            BookVM obj = new BookVM();
            obj.PublisherList = _db.Publishers.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Publisher_Id.ToString()
            });
            if (id == null)
            {
                return View(obj);
            }
            //this for edit
            obj.Book = _db.Books.FirstOrDefault(u => u.Book_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(BookVM obj)
        {
                if (obj.Book.Book_Id == 0)
                {
                    //this is create
                    _db.Books.Add(obj.Book);
                }
                else
                {
                    //this is update
                    _db.Books.Update(obj.Book);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int id)
        {
            var objFromDB = _db.Books.FirstOrDefault(o => o.Book_Id == id);
            _db.Books.Remove(objFromDB);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult PlayGround()
        {
            var bookTemp = _db.Books.FirstOrDefault();
            bookTemp.Price = 100;

            var bookCollection = _db.Books;
            double totalPrice = 0;

            foreach (var book in bookCollection)
            {
                totalPrice += book.Price;
            }

            var bookList = _db.Books.ToList();
            foreach (var book in bookList)
            {
                totalPrice += book.Price;
            }

            var bookCollection2 = _db.Books;
            var bookCount1 = bookCollection2.Count();

            var bookCount2 = _db.Books.Count();
            return RedirectToAction(nameof(Index));
        }


    }
}
