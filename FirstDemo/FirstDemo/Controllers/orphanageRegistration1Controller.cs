using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FirstDemo.Models;

namespace FirstDemo.Controllers
{
    public class orphanageRegistration1Controller : ApiController
    {
        private ActionLearningEntities db = new ActionLearningEntities();

        // GET: api/orphanageRegistration1
        public IQueryable<orphanageRegistration1> GetorphanageRegistration1()
        {
            return db.orphanageRegistration1;
        }

        // GET: api/orphanageRegistration1/5
        [ResponseType(typeof(orphanageRegistration1))]
        public IHttpActionResult GetorphanageRegistration1(int id)
        {
            orphanageRegistration1 orphanageRegistration1 = db.orphanageRegistration1.Find(id);
            if (orphanageRegistration1 == null)
            {
                return NotFound();
            }

            return Ok(orphanageRegistration1);
        }

        // PUT: api/orphanageRegistration1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutorphanageRegistration1(int id, orphanageRegistration1 orphanageRegistration1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orphanageRegistration1.oId)
            {
                return BadRequest();
            }

            db.Entry(orphanageRegistration1).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!orphanageRegistration1Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/orphanageRegistration1
        [ResponseType(typeof(orphanageRegistration1))]
        public IHttpActionResult PostorphanageRegistration1(orphanageRegistration1 orphanageRegistration1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.orphanageRegistration1.Add(orphanageRegistration1);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = orphanageRegistration1.oId }, orphanageRegistration1);
        }

        // DELETE: api/orphanageRegistration1/5
        [ResponseType(typeof(orphanageRegistration1))]
        public IHttpActionResult DeleteorphanageRegistration1(int id)
        {
            orphanageRegistration1 orphanageRegistration1 = db.orphanageRegistration1.Find(id);
            if (orphanageRegistration1 == null)
            {
                return NotFound();
            }

            db.orphanageRegistration1.Remove(orphanageRegistration1);
            db.SaveChanges();

            return Ok(orphanageRegistration1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool orphanageRegistration1Exists(int id)
        {
            return db.orphanageRegistration1.Count(e => e.oId == id) > 0;
        }
    }
}