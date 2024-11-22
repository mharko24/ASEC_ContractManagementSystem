using ASEC_ContractManagementSystem_API.Common.Paging;
using ASEC_ContractManagementSystem_API.Data;
using ASEC_ContractManagementSystem_API.Entities;
using ASEC_ContractManagementSystem_API.Interfaces.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ASEC_ContractManagementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class SiteController : BaseController
    {
        private readonly ApplicationDbContext _db;
        private readonly IGetAssignProjectRepository _getAssignProjectRepository;
        private readonly IPaginatedRepository<SiteInstruction> _paginatedRepository;
        public SiteController(
            ApplicationDbContext db,
            IGetAssignProjectRepository getAssignProjectRepository,
            IPaginatedRepository<SiteInstruction> paginatedRepository)
        {
            _db = db;
            _getAssignProjectRepository = getAssignProjectRepository;
            _paginatedRepository = paginatedRepository;
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ExtentedPagination<SiteInstruction>>> GetSites()
        {
            var model = new ExtentedPagination<SiteInstruction>();
            model.Projects = await _getAssignProjectRepository.AssignProjects(UserId);
            return model;
        }
        [HttpGet("GetSiteData")]
        [Authorize]
        public async Task<ActionResult<PaginatedResult<SiteInstruction>>> GetSiteData(PaginatedRequest request)
        {
            var assignProjects = await _getAssignProjectRepository.AssignProjects(UserId);
            return await _paginatedRepository
                .GetPaginated(request.PageNumber,
                request.ItemsPerPage,
                x => x.ModifyDate ?? x.Date,
                x => x.CMSiteId,
                x => assignProjects.Select(s => s.ProjCode).Contains(x.ProjCode) &&
                x.ProjCode.Contains(request.SearhKeyword ?? string.Empty) ||
                x.ProjectName.Contains(request.SearhKeyword ?? string.Empty));
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
