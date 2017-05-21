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
using WebApplicationTest5;

namespace WebApplicationTest5.Controllers
{
    public class PartnersTestController : ApiController
    {
        private BetC_CRM_DatabaseEntitiesAPITest5 db = new BetC_CRM_DatabaseEntitiesAPITest5();

        // GET: api/PartnersTest
        public IQueryable<Partner> GetPartners()
        {
            return db.Partners;
        }

        // GET: api/PartnersTest/5
        [ResponseType(typeof(Partner))]
        public IHttpActionResult GetPartner(int id)
        {
            Partner partner = db.Partners.Find(id);
            if (partner == null)
            {
                return NotFound();
            }

            return Ok(partner);
        }

        // PUT: api/PartnersTest/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPartner(int id, Partner partner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partner.PartnerID)
            {
                return BadRequest();
            }

            db.Entry(partner).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartnerExists(id))
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

        // POST: api/PartnersTest
        [ResponseType(typeof(Partner))]
        public IHttpActionResult PostPartner(Partner partner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Partners.Add(partner);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = partner.PartnerID }, partner);
        }

        // DELETE: api/PartnersTest/5
        [ResponseType(typeof(Partner))]
        public IHttpActionResult DeletePartner(int id)
        {
            Partner partner = db.Partners.Find(id);
            if (partner == null)
            {
                return NotFound();
            }

            db.Partners.Remove(partner);
            db.SaveChanges();

            return Ok(partner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PartnerExists(int id)
        {
            return db.Partners.Count(e => e.PartnerID == id) > 0;
        }
    }
}