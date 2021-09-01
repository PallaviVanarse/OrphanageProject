using FirstDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstDemo.Controllers
{
    public class OrphanageController : ApiController
    {

        private ActionLearningEntities db = new ActionLearningEntities();

        public IHttpActionResult getOrphanage()
        {
            var results = db.orphanageRegistration1.ToList();
            return Ok(results);
        }


        [HttpPost]
        public IHttpActionResult OrphanageRegistration(orphanageRegistration1 orp)
        {
            db.orphanageRegistration1.Add(orp);
            db.SaveChanges();
            return Ok();
        }
    }
}
