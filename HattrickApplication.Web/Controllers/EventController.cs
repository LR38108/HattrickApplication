using HattrickApplication.Dal;
using HattrickApplication.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

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

            if (Session["Ticket"] != null)
            {
                foreach (TicketItem t in (List<TicketItem>)Session["Ticket"])
                {
                    if (t.Event.IsTopEvent)
                    {
                        TempData["Ticket"] += "<tr class='ticketitem' id='TipsCheckBoxGroupTop'><td id ='" + t.Event.Id + "'>" + t.Event.Id + "</td><td>" + t.Event.Home.Name + "-" + t.Event.Away.Name + " </td ><td>" + t.TipType + " </td ><td class='coeff'>" + t.TipOdd + "</td><td><button class='removeEvent' type='button'>X</button></td></tr>";
                    }
                    else
                    {
                        TempData["Ticket"] += "<tr class='ticketitem' id='TipsCheckBoxGroup" + t.Event.Id + "'><td id ='" + t.Event.Id + "'>" + t.Event.Id + "</td><td>" + t.Event.Home.Name + "-" + t.Event.Away.Name + " </td ><td>" + t.TipType + " </td ><td class='coeff'>" + t.TipOdd + "</td><td><button class='removeEvent' type='button'>X</button></td></tr>";

                    }
                }
            }

            return View(unitOfWork.Events.GetAll());
        }

        public ActionResult AddToSession(string rowClass, int id, string tip, decimal coefficient)
        {
            List<TicketItem> itemsList = (List<TicketItem>)Session["Ticket"];
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
            }
            else if (hasTopEvents.Any() && t.Event.IsTopEvent)
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

            return Json(new { success = true });
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
            return Json(new { success = true });
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
        public ActionResult Create([Bind(Include = "Id,SportId,HomeId,AwayId,Start,End,Result,Tip1,Tip2,TipX,Tip1X,TipX2,Tip12,IsTopEvent")] Event anEvent)
        {
            ViewBag.SportId = new SelectList(unitOfWork.Sports.GetAll().OrderBy(s => s.Name), "Id", "Name");
            ViewBag.HomeId = new SelectList(unitOfWork.Teams.GetAll().OrderBy(s => s.Name), "Id", "Name");
            ViewBag.AwayId = new SelectList(unitOfWork.Teams.GetAll().OrderBy(s => s.Name), "Id", "Name");
            anEvent = EventValidations(anEvent);
            if (ModelState.IsValid)
            {
                unitOfWork.Events.Add(anEvent);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            return View(anEvent);
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
            return View(anEvent);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SportId,HomeId,Home,AwayId,Away,Start,End,Result,Tip1,Tip2,TipX,Tip1X,TipX2,Tip12,IsTopEvent")] Event anEvent)
        {
            ViewBag.SportId = new SelectList(unitOfWork.Sports.GetAll().OrderBy(s => s.Name), "Id", "Name");
            ViewBag.HomeId = new SelectList(unitOfWork.Teams.GetAll().OrderBy(s => s.Name), "Id", "Name");
            ViewBag.AwayId = new SelectList(unitOfWork.Teams.GetAll().OrderBy(s => s.Name), "Id", "Name");
            anEvent = EventValidations(anEvent);
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


        public Event EventValidations(Event eventEntity)
        {
            eventEntity.Home = unitOfWork.Teams.GetById(eventEntity.HomeId);
            eventEntity.Away = unitOfWork.Teams.GetById(eventEntity.AwayId);
            if (eventEntity.Home.SportId != eventEntity.Away.SportId || eventEntity.HomeId == eventEntity.AwayId)
            {
                ModelState.AddModelError("InvalidTeams", "You cannot select same teams or teams from diferent sports!");
            }
            if (eventEntity.Home.SportId != eventEntity.SportId || eventEntity.Away.SportId != eventEntity.SportId)
            {
                ModelState.AddModelError("InvalidSport", "Invalid Sport!");
            }
            if (eventEntity.Start > eventEntity.End)
            {
                ModelState.AddModelError("InvalidDate", "Event cannot end before it starts!");
            }
            if (eventEntity.Tip1 < 1)
            {
                ModelState.AddModelError("Tip1LessThanOne", "Tip1 cannot be less than 1!");
            }
            else if (eventEntity.Tip2 < 1)
            {
                ModelState.AddModelError("Tip2LessThanOne", "Tip2 cannot be less than 1!");
            }
            else if (eventEntity.TipX < 1)
            {
                ModelState.AddModelError("TipXLessThanOne", "TipX cannot be less than 1!");
            }
            else if (eventEntity.Tip1X < 1)
            {
                ModelState.AddModelError("Tip1XLessThanOne", "Tip1X cannot be less than 1!");
            }
            else if (eventEntity.TipX2 < 1)
            {
                ModelState.AddModelError("TipX2LessThanOne", "TipX2 cannot be less than 1!");
            }
            else if (eventEntity.Tip12 < 1)
            {
                ModelState.AddModelError("Tip12LessThanOne", "Tip12 cannot be less than 1!");
            }

            return eventEntity;
        }
    }
}
