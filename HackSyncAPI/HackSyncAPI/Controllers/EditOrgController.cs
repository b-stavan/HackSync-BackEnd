using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HackSyncAPI;
using HackSyncAPI.Data;

namespace HackSyncAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditOrgController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public EditOrgController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/EditOrg
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrganizationModel>>> GetTbl_Organization_Master()
        {
            return await _context.Tbl_Organization_Master.ToListAsync();
        }

        // GET: api/EditOrg/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizationModel>> GetOrganizationModel(int id)
        {
            var organizationModel = await _context.Tbl_Organization_Master.FindAsync(id);

            if (organizationModel == null)
            {
                return NotFound();
            }

            return organizationModel;
        }

        // PUT: api/EditOrg/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizationModel(int id, OrganizationModel organizationModel)
        {
            if (id != organizationModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(organizationModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EditOrg
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrganizationModel>> PostOrganizationModel(OrganizationModel organizationModel)
        {
            _context.Tbl_Organization_Master.Add(organizationModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganizationModel", new { id = organizationModel.Id }, organizationModel);
        }

        // DELETE: api/EditOrg/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizationModel(int id)
        {
            var organizationModel = await _context.Tbl_Organization_Master.FindAsync(id);
            if (organizationModel == null)
            {
                return NotFound();
            }

            _context.Tbl_Organization_Master.Remove(organizationModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrganizationModelExists(int id)
        {
            return _context.Tbl_Organization_Master.Any(e => e.Id == id);
        }
    }
}
