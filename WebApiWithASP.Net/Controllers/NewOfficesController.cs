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
using System.Web.Http.Description;
using WebApiWithASP.Net.Data;
using WebApiWithASP.Net.Models;

namespace WebApiWithASP.Net.Controllers
{
    public class NewOfficesController : ApiController
    {
        private WebApiWithASPNetContext db = new WebApiWithASPNetContext();

        // GET: api/NewOffices
        public IQueryable<NewOffice> GetNewOffices()
        {
            return db.NewOffices;
        }

        // GET: api/NewOffices/5
        [ResponseType(typeof(NewOffice))]
        public async Task<IHttpActionResult> GetNewOffice(int id)
        {
            NewOffice newOffice = await db.NewOffices.FindAsync(id);
            if (newOffice == null)
            {
                return NotFound();
            }

            return Ok(newOffice);
        }

        // PUT: api/NewOffices/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNewOffice(int id, NewOffice newOffice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newOffice.Id)
            {
                return BadRequest();
            }

            db.Entry(newOffice).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewOfficeExists(id))
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

        // POST: api/NewOffices
        [ResponseType(typeof(NewOffice))]
        public async Task<IHttpActionResult> PostNewOffice(NewOffice newOffice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NewOffices.Add(newOffice);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = newOffice.Id }, newOffice);
        }

        // DELETE: api/NewOffices/5
        [ResponseType(typeof(NewOffice))]
        public async Task<IHttpActionResult> DeleteNewOffice(int id)
        {
            NewOffice newOffice = await db.NewOffices.FindAsync(id);
            if (newOffice == null)
            {
                return NotFound();
            }

            db.NewOffices.Remove(newOffice);
            await db.SaveChangesAsync();

            return Ok(newOffice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NewOfficeExists(int id)
        {
            return db.NewOffices.Count(e => e.Id == id) > 0;
        }
    }
}