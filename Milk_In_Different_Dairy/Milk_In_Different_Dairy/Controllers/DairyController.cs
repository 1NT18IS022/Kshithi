using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Milk_In_Different_Dairy.Database;
using Milk_In_Different_Dairy.Models;

namespace Milk_In_Different_Dairy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DairyController : ControllerBase
    {
        private readonly datacontext _context;
        private readonly ILog logger;
        public DairyController(datacontext context)
        {
            _context = context;
            logger=LogManager.GetLogger(typeof(DairyController)); 
        }


        [HttpGet("get")]
        public async Task<ActionResult<dairy>> get()
        {
            return Ok( await _context.Dairys.ToListAsync<dairy>());
        }
     

        [HttpPost("add")]
        public async Task<ActionResult> add(dairy data)
        {
            if(data == null)
            {
                logger.Warn("Attempt to create dairy object failed");
                return BadRequest("entter all details");
            }
      await _context.Dairys.AddAsync(data);
            int res = (await _context.SaveChangesAsync());
            return Ok(await _context.Dairys.ToListAsync<dairy>());

        }

        [HttpPut("update")]
        public async Task<ActionResult<dairy>> update(dairy d)
        {
           dairy _dairy= await   _context.Dairys.Where(x=>x.Dairy_id==d.Dairy_id).FirstOrDefaultAsync<dairy>();
            if (_dairy == null)
            {
                logger.Warn("Attempt to update dairy object failed");
                return BadRequest("not found ");
            }

            _dairy.Dairy_Name=d.Dairy_Name;
            int res = (await _context.SaveChangesAsync());
            return Ok(await _context.Dairys.ToListAsync<dairy>());

        }



        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> delete(int id)
        {
            dairy _dairy = await _context.Dairys.Where(x => x.Dairy_id == id).FirstOrDefaultAsync<dairy>();
            if (_dairy == null)
            {
                logger.Warn("attempt to delete dairy object failed");
                return BadRequest("not found ");
            }

           _context.Dairys.Remove(_dairy);
            int res = (await _context.SaveChangesAsync());
            return Ok(await _context.Dairys.ToListAsync<dairy>());

        }

    }
}
