using HattrickApplication.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HattrickApplication.Entities;

namespace HattrickApplication.Web.Controllers
{
    public class SportController : Controller
    {
        private IUnitOfWork unitOfWork;

        public SportController()
        {
            this.unitOfWork = new UnitOfWork(new HattrickApplicationContext());
        }

        public SportController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Sport
        public ActionResult Index()
        {

            return View(unitOfWork.Sports.GetAll());
        }


        // GET: Sport/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sport sport = unitOfWork.Sports.Find(e => e.Id == id).FirstOrDefault();
            if (sport == null)
            {
                return HttpNotFound();
            }
            return View(sport);
        }

        // GET: Sport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sport/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] Sport sport)
        {

            ViewBag.SportId = new SelectList(unitOfWork.Sports.GetAll(), "Id", "Name");
            if (ModelState.IsValid)
            {
                unitOfWork.Sports.Add(sport);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            return View(sport);
        }


        // GET: Sport/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sport sport = unitOfWork.Sports.Find(e => e.Id == id).FirstOrDefault();
            if (sport == null)
            {
                return HttpNotFound();
            }
            return View(sport);
        }

        // POST: Sport/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name")] Sport sport)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Sports.UpdateSport(sport);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(sport);
        }

        // GET: Sport/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sport sport = unitOfWork.Sports.Find(e => e.Id == id).FirstOrDefault();
            if (sport == null)
            {
                return HttpNotFound();
            }
            return View(sport);
        }

        // POST: Sport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sport sport = unitOfWork.Sports.Find(e => e.Id == id).FirstOrDefault();
            unitOfWork.Sports.Remove(sport);
            unitOfWork.Complete();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
