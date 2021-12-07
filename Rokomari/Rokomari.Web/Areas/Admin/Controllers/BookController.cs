using Microsoft.AspNetCore.Mvc;
using Rokomari.Infrastructure;
using Rokomari.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rokomari.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            var model = new BookListModel();
            model.GetBooksList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateBookModel();

            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateBookModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.AddBook();
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Failed to create course");
                }
            }
            return View(model);
        }
        
        public JsonResult GetBooksData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new BookListModel();
            var data = model.GetBooks(dataTablesModel);
            return Json(data);
        }


        public IActionResult Edit(int id)
        {
            var model = new EditBookModel();
            model.LoadBookData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditBookModel model)
        {
            model.Update();
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var model = new BookListModel();
            model.Delete(id);
            return Redirect(nameof(Index));
        }
    }
}
