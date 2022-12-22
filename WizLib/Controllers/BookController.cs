using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WizLib_DataAccess.Data;
using WizLib_Models.Models;
using WizLib_Models.ViewModels;

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
            List<Book> objList = _db.Books.ToList();
            return View(objList);
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Upsert(Category obj)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        if(obj.Category_Id == 0)
        //        {
        //            //this is create
        //            _db.Categories.Add(obj);

        //        }
        //        else
        //        {
        //            //this is update
        //            _db.Categories.Update(obj);
        //        }
        //        _db.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(obj);

        //}

        //public IActionResult Delete(int id)
        //{
        //    var objFromDB = _db.Categories.FirstOrDefault(o => o.Category_Id == id);
        //    _db.Categories.Remove(objFromDB);
        //    _db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}

        //public IActionResult CreateMultiple2()
        //{
        //    List<Category> catlist = new List<Category>();

        //    for(int i = 1; i<= 2; i++)
        //    {
        //        catlist.Add(new Category { Name = Guid.NewGuid().ToString() });

        //       // _db.Categories.Add(new Category { Name = Guid.NewGuid().ToString() });
        //    }
        //    _db.Categories.AddRange(catlist);
        //    _db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}

        //public IActionResult CreateMultiple5()
        //{
        //    List<Category> catlist = new List<Category>();

        //    for (int i = 1; i <= 5; i++)
        //    {
        //        catlist.Add(new Category { Name = Guid.NewGuid().ToString() });

        //        // _db.Categories.Add(new Category { Name = Guid.NewGuid().ToString() });
        //    }
        //    _db.Categories.AddRange(catlist);
        //    _db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}


        //public IActionResult RemoveMultiple2()
        //{
        //    IEnumerable<Category> catlist = _db.Categories.OrderByDescending(o => o.Category_Id).Take(2).ToList();

        //    _db.Categories.RemoveRange(catlist);
        //    _db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}

        //public IActionResult RemoveMultiple5()
        //{
        //    IEnumerable<Category> catlist = _db.Categories.OrderByDescending(o => o.Category_Id).Take(5).ToList();

        //    _db.Categories.RemoveRange(catlist);
        //    _db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}

    }
}
