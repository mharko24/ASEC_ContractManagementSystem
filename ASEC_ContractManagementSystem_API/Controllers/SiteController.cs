using ASEC_ContractManagementSystem_API.Data;
using ASEC_ContractManagementSystem_API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ASEC_ContractManagementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public SiteController(
            ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SiteInstruction>>> GetSites()
        {
            var sites = await _db.SiteInstructions.ToListAsync();
            if(sites !=null && sites.Count > 0)
            {
                return sites;
            }
            return NotFound();
        }
        [HttpGet("{CMSiteId}")]
        public async Task<ActionResult<SiteInstruction>> GetSite(int CMSiteId)
        {
            var site = await _db.SiteInstructions.FindAsync(CMSiteId);
            if (site != null)
            {
                return site;
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult<SiteInstruction>> CreateSite(SiteInstruction site)
        {
            await _db.SiteInstructions.AddAsync(site);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSite), new { CMSiteId = site.CMSiteId }, site);
        }
        [HttpPut]
        public async Task<ActionResult<SiteInstruction>>UpdateSite(int CMSiteId, SiteInstruction site)
        {
            if(CMSiteId!= site.CMSiteId)
            {
                return BadRequest();
            }
            _db.Entry(site).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DBConcurrencyException)
            {
                if (!SiteExist(CMSiteId))
                {
                    return NotFound();
                }
                else
                {
                    { throw; }
                }
            }
            return NoContent();
        }
        [HttpDelete("{CMSiteId}")]
        public async Task<ActionResult<SiteInstruction>> DeleteSite(int CMSiteId)
        {
            if(_db.SiteInstructions is null)
            {
                return NotFound();
            }
            var site = await _db.SiteInstructions.FindAsync(CMSiteId);
            if (site == null) 
                    return NotFound();
            _db.SiteInstructions.Remove(site);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        private bool SiteExist(int CMSiteId)
        {
            return (_db.SiteInstructions?.Any(x => x.CMSiteId == CMSiteId)).GetValueOrDefault();
        }
    }
}
