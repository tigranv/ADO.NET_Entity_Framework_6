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
        //public List<Contact> GetPartners()
        //{
        //    //return db.Contacts;
        //    //return db.Database.SqlQuery<Contact>("exec [dbo].[GetByPage]", 2, 2, 1).ToList();
        //    return db.GetByPage(2, 2, true);
        //}

        public IQueryable<Contact> GetPartners()
        {
            return db.Contacts;
        }

        // GET: api/Partners/5
        [ResponseType(typeof(Contact))]
        public IHttpActionResult GetPartner(int id)
        {
            Contact partner = db.Contacts.Find(id);
            if (partner == null)
            {
                return NotFound();
            }

            return Ok(partner);
        }

        // PUT: api/Partners/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPartner([FromBody] Contact partner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = partner.ContactId;
            var PartnerToUpdate = db.Contacts.Find(id);

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
        [ResponseType(typeof(Contact))]
        public IHttpActionResult PostPartner(Contact partner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            partner.DateInserted = DateTime.UtcNow;
            partner.GuID = Guid.NewGuid();
            db.Contacts.Add(partner);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = partner.ContactId }, partner);
        }

        // DELETE: api/Partners/5
        [ResponseType(typeof(Contact))]
        public IHttpActionResult DeletePartner(int id)
        {
            Contact partner = db.Contacts.Find(id);
            if (partner == null)
            {
                return NotFound();
            }

            db.Contacts.Remove(partner);
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
            return db.Contacts.Count(e => e.ContactId == id) > 0;
        }
    }
}