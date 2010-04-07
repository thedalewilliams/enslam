using System;
using System.Web.Mvc;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using Castle.Services.Transaction;
using Enslam.Common.Repositories;
using Enslam.Site.Models;
using TransactionMode=Castle.Services.Transaction.TransactionMode;
using System.Linq;
namespace Enslam.Site.Controllers
{
    [Transactional]
    public class TestController : Controller
    {
        private readonly IRepository<Test> _testRepository;

        public TestController(IRepository<Test> testRepository)
        {
            _testRepository = testRepository;
        }

        //
        // GET: /Test/

        public ActionResult Index()
        {
            var tests = _testRepository.GetAll().ToList();
            return View(tests);
        }

        //
        // GET: /Test/Details/5

        public ActionResult Details(Guid id)
        {
            var test = _testRepository.GetById(id);
            return View(test);
        }

        //
        // GET: /Test/Create
        [Transaction(TransactionMode.Requires)]
        public virtual ActionResult Create()
        {
            var test = new Test();
            ActiveRecordMediator<Test>.Save(test);
            return View(test);
        } 

        //
        // GET: /Test/Edit/5
 
        public ActionResult Edit(Guid id)
        {
            var test = _testRepository.GetById(id);
            return View(test);
        }

        //
        // POST: /Test/Edit/5

        [HttpPost]
        public ActionResult Edit(Test test)
        {
            if(ModelState.IsValid)
            {
                _testRepository.SaveOnSubmit(test);

                return RedirectToAction("Index");
            }

            return View(test);

        }

        //
        // GET: /Test/Delete/5

        public ActionResult Delete(Guid id)
        {
            var test = _testRepository.GetById(id);
            return View(test);
        }

        //
        // POST: /Test/Delete/5

        [HttpPost]
        public ActionResult Delete(Test test)
        {
            _testRepository.DeleteOnSubmit(test);
            return RedirectToAction("Index");
        }
    }
}
