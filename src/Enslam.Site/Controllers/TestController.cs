using System;
using System.Web.Mvc;
using Castle.ActiveRecord.Framework;
using Castle.Services.Transaction;
using Enslam.Site.Models;

namespace Enslam.Site.Controllers
{
    [Transactional]
    public class TestController : Controller
    {
        private readonly ISessionFactoryHolder _sessionFactoryHolder;

        public TestController(ISessionFactoryHolder sessionFactoryHolder)
        {
            _sessionFactoryHolder = sessionFactoryHolder;
        }

        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Test/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Test/Create
        [Transaction(TransactionMode.Requires)]
        public virtual ActionResult Create()
        {
            var test = new Test();
            test.Save();

            return View(test);
        } 

        //
        // GET: /Test/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Test/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Test/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Test/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
