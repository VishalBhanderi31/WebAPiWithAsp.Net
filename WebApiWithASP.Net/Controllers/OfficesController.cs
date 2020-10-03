﻿using System;
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
    public class OfficesController : ApiController
    {
        private WebApiWithASPNetContext db = new WebApiWithASPNetContext();

        // GET: api/Offices
        public IQueryable<Office> GetOffices()
        {
            return db.Offices;
        }

        // GET: api/Offices/5
        [ResponseType(typeof(Office))]
        public async Task<IHttpActionResult> GetOffice(int id)
        {
            Office office = await db.Offices.FindAsync(id);
            if (office == null)
            {
                return NotFound();
            }

            return Ok(office);
        }

        // PUT: api/Offices/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOffice(int id, Office office)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != office.Id)
            {
                return BadRequest();
            }

            db.Entry(office).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficeExists(id))
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

        // POST: api/Offices
        [ResponseType(typeof(Office))]
        public async Task<IHttpActionResult> PostOffice(Office office)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Offices.Add(office);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = office.Id }, office);
        }

        // DELETE: api/Offices/5
        [ResponseType(typeof(Office))]
        public async Task<IHttpActionResult> DeleteOffice(int id)
        {
            Office office = await db.Offices.FindAsync(id);
            if (office == null)
            {
                return NotFound();
            }

            db.Offices.Remove(office);
            await db.SaveChangesAsync();

            return Ok(office);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OfficeExists(int id)
        {
            return db.Offices.Count(e => e.Id == id) > 0;
        }
    }
}