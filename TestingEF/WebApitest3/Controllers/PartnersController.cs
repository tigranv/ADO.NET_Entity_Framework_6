using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApitest3;

namespace WebApitest3.Controllers
{
    public class PartnersController : ApiController
    {
        private BetC_CRM_DatabaseEntitiesTest3 db = new BetC_CRM_DatabaseEntitiesTest3();

        // GET: api/Partners
        public IQueryable<Partner> GetPartners()
        {
            return db.Partners;
        }

        // GET: api/Partners/5
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

        // PUT: api/Partners/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPartner([FromBody] Partner partner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = partner.PartnerID;
            var PartnerToUpdate = db.Partners.Find(id);

            if (PartnerToUpdate == null)
            {
                return BadRequest();
            }

            PartnerToUpdate.FullName = partner.FullName;
            PartnerToUpdate.Country = partner.Country;
            PartnerToUpdate.CompanyName = partner.CompanyName;
            PartnerToUpdate.Email = partner.Email;
            PartnerToUpdate.EmailLists = partner.EmailLists;

            //db.Entry(PartnerToUpdate).State = EntityState.Modified;
            //db.Partners.AddOrUpdate(PartnerToUpdate);

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

        // POST: api/Partners
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

        // DELETE: api/Partners/5
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