using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FirstDemo.Models;

namespace FirstDemo.Controllers
{
    public class orphanageRegistrationMVCController : Controller
    {
        private ActionLearningEntities db = new ActionLearningEntities();

        // GET: orphanageRegistrationMVC
        public ActionResult Index()
        {
            return View(db.orphanageRegistration1.ToList());
        }

        // GET: orphanageRegistrationMVC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orphanageRegistration1 orphanageRegistration1 = db.orphanageRegistration1.Find(id);
            if (orphanageRegistration1 == null)
            {
                return HttpNotFound();
            }
            return View(orphanageRegistration1);
        }

        // GET: orphanageRegistrationMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: orphanageRegistrationMVC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "oId,oName,oRegistrationNum,addressLine1,addressLine2,landmark,city,state,country,pincode,phoneNum,password")] orphanageRegistration1 orphanageRegistration1)
        {
            if (ModelState.IsValid)
            {
                db.orphanageRegistration1.Add(orphanageRegistration1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orphanageRegistration1);
        }

        // GET: orphanageRegistrationMVC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orphanageRegistration1 orphanageRegistration1 = db.orphanageRegistration1.Find(id);
            if (orphanageRegistration1 == null)
            {
                return HttpNotFound();
            }
            return View(orphanageRegistration1);
        }

        // POST: orphanageRegistrationMVC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "oId,oName,oRegistrationNum,addressLine1,addressLine2,landmark,city,state,country,pincode,phoneNum,password")] orphanageRegistration1 orphanageRegistration1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orphanageRegistration1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orphanageRegistration1);
        }

        // GET: orphanageRegistrationMVC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orphanageRegistration1 orphanageRegistration1 = db.orphanageRegistration1.Find(id);
            if (orphanageRegistration1 == null)
            {
                return HttpNotFound();
            }
            return View(orphanageRegistration1);
        }

        // POST: orphanageRegistrationMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            orphanageRegistration1 orphanageRegistration1 = db.orphanageRegistration1.Find(id);
            db.orphanageRegistration1.Remove(orphanageRegistration1);
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
