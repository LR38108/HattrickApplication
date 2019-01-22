using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HattrickApplication.Dal;
using HattrickApplication.Entities;

namespace HattrickApplication.Controllers
{
    public class EventController : Controller
    {
        private IUnitOfWork unitOfWork;

        public EventController()
        {
            this.unitOfWork = new UnitOfWork(new HattrickApplicationContext());
        }

        public EventController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Event
        public ActionResult Index()
        {   
            return View(unitOfWork.Events.GetAll());
        }

        public ActionResult LatestEvents()
        {
            return View(unitOfWork.Events.GetAll());
        }

        public ActionResult AddToSession(string rowClass, int id, string tip, decimal coefficient)
        {
            List<TicketItem> itemsList = (List<TicketItem>) Session["Ticket"];
            if (itemsList == null)
            {
                itemsList = new List<TicketItem>();
            }
            Event e = unitOfWork.Events.GetById(id);
            TicketItem t = new TicketItem();
            t.Event = e;
            var rowclass = "";
            var message = "";
            if (t.Event.IsTopEvent)
            {
                rowclass = "TipsCheckBoxGroupTop";
            }
            else
            {
                rowclass = "TipsCheckBoxGroup" + t.Event.Id;
            }
            
            t.TipType = tip;
            t.TipOdd = coefficient;
            var isInList = itemsList.Where(i => i.Event.Id.Equals(id));
            var hasTopEvents = itemsList.Where(i => i.Event.IsTopEvent);
            if (isInList.Any() && !t.Event.IsTopEvent)
            {
                itemsList[itemsList.FindIndex(i => i.Event.Id.Equals(id))] = t;
                message = "updated";
            }else if (hasTopEvents.Any() && t.Event.IsTopEvent)
            {
                itemsList[itemsList.FindIndex(i => i.Event.IsTopEvent)] = t;
                message = "updated";
            }
            else
            {
                itemsList.Add(t);
                message = "added";
            }

            Session["Ticket"] = itemsList;

            return Json(new { success = true, message = message, val = "<tr class=" + rowclass + "><td>" + id + "</td><td>" + e.Home.Name + e.Away.Name + "</td><td>" + tip + "</td><td>" + coefficient + "</td></tr>" });
        }
        public ActionResult DeleteSession(int eventId)
        {
            List<TicketItem> session = (List<TicketItem>)Session["Ticket"];
            Event e = unitOfWork.Events.GetById(eventId);
            foreach (var item in session)
            {
                if (item.Event.Id == eventId)
                {
                    session.Remove(item);
                    break;
                }
            }
            return Json(new { success = true});
        }

        [HttpGet]
        public ActionResult AddEvent(string rowClass, int Id, string tip, decimal coefficient)
        {
            List<TicketItem> itemsList = new List<TicketItem>();
            var ticketitem = new TicketItem();
            if (Session["Titems"] == null)
            {
                Session["Titems"] = new List<TicketItem>();
                ticketitem.Event = unitOfWork.Events.GetById(Id);
                ticketitem.TipType = tip;
                ticketitem.TipOdd = coefficient;
                itemsList.Add(ticketitem);
                Session["Titems"] = ticketitem;
            }
            else
            {
                ticketitem.Event = unitOfWork.Events.GetById(Id);
                ticketitem.TipType = tip;
                ticketitem.TipOdd = coefficient;
                itemsList.Add(ticketitem);
                Session["Titems"] = ticketitem;
            }

            //return Json(new { success = true, message = "<tr class=\"ticketitem\" id=" + rowClass + "><td id=" + Id + ">" + Id + "</td ><td>" + ticketitem.Event.Home.Name + ticketitem.Event.Away.Name + "</td > <td>" + tip + "</td > <td class=\"coeff\">" + coefficient + "</td><td><button class=\"removeEvent\" type=\"button\">X</button></td></tr >" });
            return View();
        }


        // GET: Event/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = unitOfWork.Events.Find(e => e.Id == id).FirstOrDefault();
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            ViewBag.SportId = new SelectList(unitOfWork.Sports.GetAll().OrderBy(s => s.Name), "Id", "Name");
            ViewBag.HomeId = new SelectList(unitOfWork.Teams.GetAll().OrderBy(s => s.Name), "Id", "Name");
            ViewBag.AwayId = new SelectList(unitOfWork.Teams.GetAll().OrderBy(s => s.Name), "Id", "Name");
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SportId,HomeId,AwayId,Start,End,Result,Tip1,Tip2,TipX,Tip1X,TipX2,Tip12,IsTopEvent")] Event @event)
        {
            ViewBag.SportId = new SelectList(unitOfWork.Sports.GetAll().OrderBy(s => s.Name), "Id", "Name");
            ViewBag.HomeId = new SelectList(unitOfWork.Teams.GetAll().OrderBy(s => s.Name), "Id", "Name");
            ViewBag.AwayId = new SelectList(unitOfWork.Teams.GetAll().OrderBy(s => s.Name), "Id", "Name");
            if (ModelState.IsValid)
            {
                unitOfWork.Events.Add(@event);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        [HttpPost]
        public ActionResult CreateTicket(Ticket ticket)
        {           

            if (ModelState.IsValid)
            {
                User user = unitOfWork.Users.Find(u => u.Id==1).FirstOrDefault();
                if (ticket.Bet > 10)
                {
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
                        return Json(new {success = true, message = "Ticket successfully created"});
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Insufficient funds!");
                        return Json(new {success = false, message = "Insufficient funds!"});
                    }
                }
                else
                {
                    return Json((new { success = false, message = "Invalid ammount" }));
                }
            }
            else
            {
                return Json((new { success = false, message = "Error" }));
            }
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int? id)
        {
            Event anEvent = unitOfWork.Events.Find(e => e.Id == id).FirstOrDefault();

            ViewBag.SportId = new SelectList(unitOfWork.Sports.GetAll().OrderBy(s => s.Name), "Id", "Name", anEvent.SportId);
            ViewBag.HomeId = new SelectList(unitOfWork.Teams.GetAll().OrderBy(s => s.Name), "Id", "Name", anEvent.Home.Id);
            ViewBag.AwayId = new SelectList(unitOfWork.Teams.GetAll().OrderBy(s => s.Name), "Id", "Name", anEvent.Away.Id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (anEvent == null)
            {
                return HttpNotFound();
            }
            return View(anEvent);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SportId,HomeId,AwayId,Start,End,Result,Tip1,Tip2,TipX,Tip1X,TipX2,Tip12,IsTopEvent")] Event anEvent)
        {
            ViewBag.SportId = new SelectList(unitOfWork.Sports.GetAll().OrderBy(s => s.Name), "Id", "Name");
            ViewBag.HomeId = new SelectList(unitOfWork.Teams.GetAll().OrderBy(s => s.Name), "Id", "Name");
            ViewBag.AwayId = new SelectList(unitOfWork.Teams.GetAll().OrderBy(s => s.Name), "Id", "Name");
            if (ModelState.IsValid)
            {
                unitOfWork.Events.UpdateEvent(anEvent);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(anEvent);
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = unitOfWork.Events.Find(e => e.Id == id).FirstOrDefault();
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = unitOfWork.Events.Find(e => e.Id == id).FirstOrDefault();
            unitOfWork.Events.Remove(@event);
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
