using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HattrickApplication.Dal;
using HattrickApplication.Entities;

namespace HattrickApplication.Web.Controllers
{
    public class TeamController : Controller
    {
        private IUnitOfWork unitOfWork;

        public TeamController()
        {
            this.unitOfWork = new UnitOfWork(new HattrickApplicationContext());
        }

        public TeamController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Team
        public ActionResult Index()
        {

            return View(unitOfWork.Teams.GetAll());
        }


        // GET: Team/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = unitOfWork.Teams.Find(e => e.Id == id).FirstOrDefault();
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // GET: Team/Create
        public ActionResult Create()
        {
            ViewBag.SportId = new SelectList(unitOfWork.Sports.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Team/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Sport, SportId, Name")] Team team)
        {

            ViewBag.SportId = new SelectList(unitOfWork.Sports.GetAll(), "Id", "Name");
            if (ModelState.IsValid)
            {
                unitOfWork.Teams.Add(team);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            return View(team);
        }


        // GET: Team/Edit/5
        public ActionResult Edit(int? id)
        {
            Team team = unitOfWork.Teams.Find(t => t.Id == id).FirstOrDefault();
            ViewBag.SportId = new SelectList(unitOfWork.Sports.GetAll(), "Id", "Name", team.SportId);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Team/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Sport, SportId, Name")] Team team)
        {
            ViewBag.SportId = new SelectList(unitOfWork.Sports.GetAll(), "Id", "Name", team.SportId);
            if (ModelState.IsValid)
            {
                unitOfWork.Teams.UpdateTeam(team);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(team);
        }

        // GET: Team/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = unitOfWork.Teams.Find(e => e.Id == id).FirstOrDefault();
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Team team = unitOfWork.Teams.Find(e => e.Id == id).FirstOrDefault();
            unitOfWork.Teams.Remove(team);
            unitOfWork.Complete();
            return RedirectToAction("Index");
        }


    }
}
