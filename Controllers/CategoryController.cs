using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NimapInfotech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NimapInfotech.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IConfiguration configuration;
        CategoryNAT nat;

        public CategoryController(IConfiguration configuration)
        {
            this.configuration = configuration;
            nat = new CategoryNAT(this.configuration);
        }
        // GET: CategoryController
        public ActionResult Index()
        {

            var list = nat.CatList();
            return View(list);
        }


        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category cat)
        {
            try
            {
                int result=nat.AddCat(cat);
                if (result == 1)


                { return RedirectToAction(nameof(Index)); }

                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var cat = nat.GetCatById(id);
            return View(cat);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category cat)
        {
            try
            {
                int result = nat.UpdateCat(cat);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var cat = nat.GetCatById(id);
            return View(cat);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = nat.DeleteCat(id);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
