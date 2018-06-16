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
    public class DoctorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Doctor
        public ActionResult Index()
        {
            return View(db.ClientRecordings.ToList());
        }

        // GET: Doctor/Details/5
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

    

        // GET: Doctor/Edit/5
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

        // POST: Doctor/Edit/5
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
