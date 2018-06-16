using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebDoctor.Models;

namespace WebDoctor.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Admin
        public ActionResult Index()
        {
            var clients = db.Users;
            var recordings = db.ClientRecordings;

            ViewBag.Clients = clients;
            ViewBag.Recordings = recordings;

            ViewBag.Message = "Контролер админа";

            return View();
        }

        // GET: Admin/Create
        public ActionResult CreateClient()
        {
            //var specialisation = db.ClientRecordings.Select(x => x.Specialisation).Distinct();
            //ViewBag.Specialisation = new SelectList(specialisation);

            //var doctorName = db.ClientRecordings.Select(x => x.DoctorName).Distinct();
            //ViewBag.DoctorName = new SelectList(doctorName);

            return View();
        }

        // POST: Admin/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateClient([Bind(Include = "Email, UserName, FirstName, LastName, FatherName, IIN, Sex, Address")] ApplicationUser user)
        {

            if (ModelState.IsValid)
            {
                var createdUser = new ApplicationUser
                {
                    UserName = user.Email,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    FatherName = user.FatherName,
                    IIN = user.IIN,
                    Sex = user.Sex,
                    Address = user.Address,
                    Phone = user.Phone
                };

                await UserManager.CreateAsync(createdUser, user.Email);
                //db.Users.Add(createdUser);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }
    }
}