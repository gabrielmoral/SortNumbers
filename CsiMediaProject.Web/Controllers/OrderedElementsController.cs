using CsiMediaProject.Web.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CsiMediaProject.Web.Controllers
{
    public class OrderedElementsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        public ActionResult Index()
        {
            return View(db.OrderedElements.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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
            if (ModelState.IsValid)
            {
                db.OrderedElements.Add(orderedElement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderedElement);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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
            if (ModelState.IsValid)
            {
                db.Entry(orderedElement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderedElement);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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