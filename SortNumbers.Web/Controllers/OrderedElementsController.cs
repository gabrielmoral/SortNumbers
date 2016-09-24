using SortNumbers.Web.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SortNumbers.Web.Controllers
{
    public class OrderedElementsController : Controller
    {
        private readonly DatabaseContext db;

        public OrderedElementsController()
        {
            this.db = new DatabaseContext();
        }

        public OrderedElementsController(DatabaseContext db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            return View(db.OrderedElements.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            OrderedElement orderedElement = db.OrderedElements.Find(id);

            if (orderedElement == null)
            {
                return HttpNotFound();
            }
            return View(orderedElement);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Numbers,SortType,SortDuration")] OrderedElement orderedElement)
        {
            if (!ModelState.IsValid) return View(orderedElement);

            ActionResult result = SortElement(orderedElement);

            if (result == null)
            {
                orderedElement.Sort();
                db.OrderedElements.Add(orderedElement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return result;
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            OrderedElement orderedElement = db.OrderedElements.Find(id);
            if (orderedElement == null)
            {
                return HttpNotFound();
            }
            return View(orderedElement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Numbers,SortType,SortDuration")] OrderedElement orderedElement)
        {
            if (!ModelState.IsValid) return View(orderedElement);

            ActionResult result = SortElement(orderedElement);

            if (result == null)
            {
                db.Entry(orderedElement).State = EntityState.Modified;
                db.SaveChanges();
                result = RedirectToAction("Index");
            }

            return result;
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            OrderedElement orderedElement = db.OrderedElements.Find(id);

            if (orderedElement == null)
            {
                return HttpNotFound();
            }
            return View(orderedElement);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderedElement orderedElement = db.OrderedElements.Find(id);
            db.OrderedElements.Remove(orderedElement);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private ActionResult SortElement(OrderedElement orderedElement)
        {
            ActionResult result = null;

            try
            {
                orderedElement.Sort();
            }
            catch (OverflowException)
            {
                ModelState.AddModelError(nameof(orderedElement.Numbers), "Invalid integers");
                result = View(orderedElement);
            }

            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}