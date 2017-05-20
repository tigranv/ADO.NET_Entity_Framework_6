using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using WebApi_Server;

namespace WebApi_Server.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using WebApi_Server;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Partner>("Partners");
    builder.EntitySet<EmailList>("EmailLists"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PartnersController : ODataController
    {
        private BetC_CRM_DatabaseEntities db = new BetC_CRM_DatabaseEntities();

        // GET: odata/Partners
        [EnableQuery]
        public IQueryable<Partner> GetPartners()
        {
            return db.Partners;
        }

        // GET: odata/Partners(5)
        [EnableQuery]
        public SingleResult<Partner> GetPartner([FromODataUri] int key)
        {
            return SingleResult.Create(db.Partners.Where(partner => partner.PartnerID == key));
        }

        // PUT: odata/Partners(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Partner> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Partner partner = await db.Partners.FindAsync(key);
            if (partner == null)
            {
                return NotFound();
            }

            patch.Put(partner);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartnerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(partner);
        }

        // POST: odata/Partners
        public async Task<IHttpActionResult> Post(Partner partner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Partners.Add(partner);
            await db.SaveChangesAsync();

            return Created(partner);
        }

        // PATCH: odata/Partners(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Partner> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Partner partner = await db.Partners.FindAsync(key);
            if (partner == null)
            {
                return NotFound();
            }

            patch.Patch(partner);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartnerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(partner);
        }

        // DELETE: odata/Partners(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Partner partner = await db.Partners.FindAsync(key);
            if (partner == null)
            {
                return NotFound();
            }

            db.Partners.Remove(partner);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Partners(5)/EmailLists
        [EnableQuery]
        public IQueryable<EmailList> GetEmailLists([FromODataUri] int key)
        {
            return db.Partners.Where(m => m.PartnerID == key).SelectMany(m => m.EmailLists);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PartnerExists(int key)
        {
            return db.Partners.Count(e => e.PartnerID == key) > 0;
        }
    }
}
