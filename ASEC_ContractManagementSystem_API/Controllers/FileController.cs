using ASEC_ContractManagementSystem_API.Data;
using ASEC_ContractManagementSystem_API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ASEC_ContractManagementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public FileController(
            ApplicationDbContext db)
        {
            _db = db;
            
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FileUpload>>> GetFiles()
        {
            var files = await _db.FileUploads.ToListAsync();
            if (files != null)
            {
                return files;
            }
            return NoContent();
        }
        [HttpGet("{FileId}")]
        public async Task<ActionResult<FileUpload>> GetFile(int FileId) 
        {
            var file = await _db.FileUploads.FindAsync(FileId);
            if (file != null)
            {
                return file;
            }
            return NotFound();
        }
        [HttpGet("GetFiles")]
        public async Task<ActionResult<IEnumerable<FileUpload>>> Files(int? CMSiteId, int? PotId)
        {
            if (CMSiteId.HasValue)
            {
                var files = await _db.FileUploads.Where(x => x.CMSiteId == CMSiteId).ToListAsync();

                if (files != null)
                {
                    return files;
                }
            }
            else if (PotId.HasValue)
            {
                var files = await _db.FileUploads.Where(x => x.PotId == PotId).ToListAsync();

                if (files != null)
                {
                    return files;
                }
            }
          
               
            
            //if (potid != null && potid.HasValue)
            //{
            //    var files = await _db.FileUploads.Where(x => x.PotId == potid).ToListAsync();
            //    if (files != null)
            //    {
            //        return files;
            //    }
            //}
            return NoContent();
        }

    }
}
