using APIOracle.WebApplication.Models.Autor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Windows.Documents;

namespace APIOracle.WebApplication.Controllers
{
    public class AutorController : Controller
    {
        AutorModel model;
        public AutorController()
        {
            this.model = new AutorModel();
        }
        [AsyncTimeout(1000)]
        public async Task<ActionResult> Index()
        {
            List<AutorEntity> cList = await model.GetAutor();
            return View(cList);
        }
        // GET: Contacts/Details/5
        public async Task<ActionResult> Details(int id)
        {
            AutorEntity a = await model.GetAutorByID(id);
            return View(a);
        }

        // GET: /Create
        public async Task<ActionResult> Create()
        {
            return View();
        }
        // POST: /Create
        [HttpPost]
        public async Task<ActionResult> Create(AutorEntity c)
        {
            try
            {
                await model.AddAutor(c);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: /Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            AutorEntity c = await model.GetAutorByID(id);
            return View(c);
        }
        // POST: Contacts/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(AutorEntity c)
        {
            try
            {
                await model.EditAutor(c);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacts/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            await model.DeleteAutor(id);
            return RedirectToAction("Index");
        }
    }
}
