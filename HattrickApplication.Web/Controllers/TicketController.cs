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
    public class TicketController : Controller
    {
        private IUnitOfWork unitOfWork;

        public TicketController()
        {
            this.unitOfWork = new UnitOfWork(new HattrickApplicationContext());
        }

        public TicketController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Ticket
        public ActionResult Index()
        {

            return View(unitOfWork.Tickets.GetAll());
        }

        public ActionResult UserTickets()
        {

            return View(unitOfWork.Tickets.UserTickets(1));
        }

        // GET: Ticket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = unitOfWork.Tickets.Find(e => e.Id == id).FirstOrDefault();
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Ticket/Create
        public ActionResult Create()
        {
            ViewBag.SportId = new SelectList(unitOfWork.Sports.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Ticket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, User, DateOfSubmission, IsWinning, Bet, TotalOdd, PotentialWinnings, TicketItems")] Ticket ticket)
        {

            ViewBag.SportId = new SelectList(unitOfWork.Sports.GetAll(), "Id", "Name");
            if (ModelState.IsValid)
            {
                unitOfWork.Tickets.Add(ticket);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            return View(ticket);
        }

        [HttpPost]
        public ActionResult CreateTicket(Ticket ticket)
        {

            if (ModelState.IsValid)
            {
                User user = unitOfWork.Users.Find(u => u.Id == 1).FirstOrDefault();
                if (user.Balance > ticket.Bet)
                {
                    user.Balance -= ticket.Bet;
                    ticket.User = user;
                    foreach (var ti in ticket.TicketItems)
                    {
                        ti.Event = unitOfWork.Events.Find(e => e.Id == ti.Event.Id).FirstOrDefault();
                    }
                    ticket.DateOfSubmission = DateTime.Now;
                    unitOfWork.Tickets.Add(ticket);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "Ticket successfully created" });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Insufficient funds!");
                    return Json(new { success = false, message = "Insufficient funds!" });
                }


            }

            return View();
        }

        // GET: Ticket/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.UserId = new SelectList(unitOfWork.Users.GetAll().OrderBy(u => u.Id), "Id", "Id");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = unitOfWork.Tickets.Find(e => e.Id == id).FirstOrDefault();
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Ticket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, UserId, DateOfSubmission, IsWinning, Bet, TotalOdd, PotentialWinnings, TicketItems")] Ticket ticket)
        {
            ViewBag.UserId = new SelectList(unitOfWork.Users.GetAll().OrderBy(u => u.Id), "Id", "Id");
            if (ModelState.IsValid)
            {
                unitOfWork.Tickets.UpdateTicket(ticket);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        // GET: Ticket/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = unitOfWork.Tickets.Find(e => e.Id == id).FirstOrDefault();
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = unitOfWork.Tickets.Find(e => e.Id == id).FirstOrDefault();
            unitOfWork.Tickets.Remove(ticket);
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
