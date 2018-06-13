using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebDoctor.Models;

namespace WebDoctor.Controllers
{
    public class ClientController : Controller
    {
        private ClientRecordingContext db = new ClientRecordingContext();

        // GET: Client
        public ActionResult Index()
        {
            return View(db.ClientRecordings.ToList());
        }

        // GET: Client/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientRecording clientRecording = db.ClientRecordings.Find(id);
            if (clientRecording == null)
            {
                return HttpNotFound();
            }
            return View(clientRecording);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            var specialisation = db.ClientRecordings.Select(x=>x.Specialisation).Distinct();
            ViewBag.Specialisation = new SelectList(specialisation);

            var doctorName = db.ClientRecordings.Select(x => x.DoctorName).Distinct();
            ViewBag.DoctorName = new SelectList(doctorName);

            return View();
        }

        // POST: Client/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Time,Specialisation,DoctorName,AdditionalInfo,Status,ClientName,Diagnos")] ClientRecording clientRecording)
        {
            if (ModelState.IsValid)
            {
                db.ClientRecordings.Add(clientRecording);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientRecording);
        }

        // GET: Client/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientRecording clientRecording = db.ClientRecordings.Find(id);
            if (clientRecording == null)
            {
                return HttpNotFound();
            }
            return View(clientRecording);
        }

        // POST: Client/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Time,Specialisation,DoctorName,AdditionalInfo,Status,ClientName,Diagnos")] ClientRecording clientRecording)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientRecording).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientRecording);
        }

        // GET: Client/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientRecording clientRecording = db.ClientRecordings.Find(id);
            if (clientRecording == null)
            {
                return HttpNotFound();
            }
            return View(clientRecording);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ClientRecording clientRecording = db.ClientRecordings.Find(id);
            db.ClientRecordings.Remove(clientRecording);
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
