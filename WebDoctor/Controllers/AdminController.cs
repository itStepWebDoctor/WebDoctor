using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDoctor.Models;

namespace WebDoctor.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ClientRecordingContext dbRec = new ClientRecordingContext();
        
        // GET: Admin
        public ActionResult Index()
        {
            var clients = db.Users;
            var recordings = dbRec.ClientRecordings;
            ViewBag.Clients = clients;
            ViewBag.Recordings = recordings;

            ViewBag.Message = "Контролер админа";

            return View();
        }
    }
}