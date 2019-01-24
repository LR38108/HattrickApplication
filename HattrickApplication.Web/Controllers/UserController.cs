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

namespace HattrickApplication.Controllers
{
    public class UserController : Controller
    {
        private IUnitOfWork unitOfWork;

        public UserController()
        {
            this.unitOfWork = new UnitOfWork(new HattrickApplicationContext());
        }

        public UserController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: User
        public ActionResult Index()
        {

            return View(unitOfWork.Users.GetAll());
        }


        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = unitOfWork.Users.Find(e => e.Id == id).FirstOrDefault();
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult My_account(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = unitOfWork.Users.Find(e => e.Id == id).FirstOrDefault();
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, FirstName, LastName, Balance")] User user)
        {

            ViewBag.SportId = new SelectList(unitOfWork.Sports.GetAll(), "Id", "Name");
            if (ModelState.IsValid)
            {
                unitOfWork.Users.Add(user);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public ActionResult CreditBalance(int id, decimal balance)
        {
            User user = unitOfWork.Users.GetById(id);
            if (user == null)
            {
                return Json(new { success = false, message = "User not found" });
            }
            else
            {
                user.Balance += balance;
                unitOfWork.Complete();
                return Json(new { success = true, message = "You successfully credited your account " + balance });
            }
        }


        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = unitOfWork.Users.Find(e => e.Id == id).FirstOrDefault();
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, FirstName, LastName, Balance")] User user)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Users.UpdateUser(user);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = unitOfWork.Users.Find(e => e.Id == id).FirstOrDefault();
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = unitOfWork.Users.Find(e => e.Id == id).FirstOrDefault();
            unitOfWork.Users.Remove(user);
            unitOfWork.Complete();
            return RedirectToAction("Index");
        }

    }
}
