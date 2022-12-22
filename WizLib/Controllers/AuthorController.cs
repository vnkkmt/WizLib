using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WizLib_DataAccess.Data;
using WizLib_Models.Models;

namespace WizLib.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Author> AuthorList = _db.Authors.ToList();
            return View(AuthorList);
        }

        public IActionResult Upsert(int? id)
        {
            Author authorUpdate = new Author();
            if (id != null)
            {
                authorUpdate = _db.Authors.FirstOrDefault(a => a.Author_Id == id);
                if(authorUpdate == null)
                {
                    return NotFound();
                }
            }
            else { return View(authorUpdate); }
            return View(authorUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Author obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Author_Id == 0)
                {
                    //this is create
                    _db.Authors.Add(obj);

                }
                else
                {
                    //this is update
                    _db.Authors.Update(obj);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);

        }

        public IActionResult Delete(int id)
        {
            var objFromDB = _db.Authors.FirstOrDefault(o => o.Author_Id == id);
            _db.Authors.Remove(objFromDB);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
