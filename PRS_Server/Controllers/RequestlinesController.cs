﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRS_Server.Models;

namespace PRS_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestlinesController : ControllerBase
    {
        private readonly prsDbAppContext _context;

        public RequestlinesController(prsDbAppContext context)
        {
            _context = context;
        }

        private async Task RefreshRequestline(Requestline requestline)
        {
            _context.Entry(requestline).State = EntityState.Detached;
            await _context.Requestlines.FindAsync(requestline.Id);
        }



        // GET: api/Requestlines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Requestline>>> GetRequestlines()
        {
            return await _context.Requestlines.ToListAsync();
        }

        // GET: api/Requestlines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Requestline>> GetRequestline(int id)
        {
            var requestline = await _context.Requestlines.FindAsync(id);

            if (requestline == null)
            {
                return NotFound();
            }

            return requestline;
        }

        // PUT: api/Requestlines/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestline(int id, Requestline requestline)
        {
            if (id != requestline.Id)
            {
                return BadRequest();
            }

            _context.Entry(requestline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestlineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            await RefreshRequestline(requestline);
            await RecalculateRequestTotal(requestline.RequestId);

            return NoContent();
        }

        // POST: api/Requestlines
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Requestline>> PostRequestline(Requestline requestline)
        {
            _context.Requestlines.Add(requestline);
            await _context.SaveChangesAsync();

            await RefreshRequestline(requestline);
            await RecalculateRequestTotal(requestline.RequestId);

            return CreatedAtAction("GetRequestline", new { id = requestline.Id }, requestline);
        }

        // DELETE: api/Requestlines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Requestline>> DeleteRequestline(int id)
        {
            var requestline = await _context.Requestlines.FindAsync(id);
            if (requestline == null)
            {
                return NotFound();
            }

            _context.Requestlines.Remove(requestline);
            await _context.SaveChangesAsync();

            return requestline;
        }

        private async Task RecalculateRequestTotal(int requestid)
        {
            var request = await _context.Requests.FindAsync(requestid);
            if (request == null) throw new Exception("Cannot find request");

            request.Total = (from r in request.Requestlines
                             select new
                             {
                                 LineTotal = r.Quantity * r.Product.Price
                             }).Sum(lt => lt.LineTotal);
            await _context.SaveChangesAsync();
        }

        private bool RequestlineExists(int id)
        {
            return _context.Requestlines.Any(e => e.Id == id);
        }
    }
}
