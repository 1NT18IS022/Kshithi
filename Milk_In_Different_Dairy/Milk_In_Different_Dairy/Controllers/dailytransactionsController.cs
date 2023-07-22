using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Milk_In_Different_Dairy.Database;
using Milk_In_Different_Dairy.Models;
using System.Diagnostics.Metrics;

namespace Milk_In_Different_Dairy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class dailytransactionsController : ControllerBase
    {
        private readonly datacontext _context;
        private readonly ILog logger;

        public dailytransactionsController (datacontext context)
        {
            _context = context;
            logger = LogManager.GetLogger (typeof (dailytransactionsController));
        }

        [HttpGet]   
        public async Task<ActionResult> get()
        {
            return Ok(await _context.Daily_records.ToListAsync<Daily_record>());
        }

        [HttpGet("getbydate/{date}")]
        public async Task<ActionResult> getbydate(DateTime date )
        {
            List<Daily_record> daily_Records = await _context.Daily_records.Where(x => x.date == date).ToListAsync<Daily_record>();
            return Ok(daily_Records);
        }


        [HttpGet("getbyid/{id}")]
        public async Task<ActionResult> getbyid(int id)
        {
            List<Daily_record> daily_Records = await _context.Daily_records.Where(x => x.Dairy_Id == id).ToListAsync<Daily_record>();
            return Ok(daily_Records);
        }

        [HttpPost("add")]
        public async Task<ActionResult> add(Daily_record data)
        {
            if (data == null)
            {
                logger.Warn("Attempt to create daily_record object failed because all fields not enterd");
                return BadRequest("enter all fields");
            }

            dairy dairy = await _context.Dairys.FindAsync(data.Dairy_Id);

            if (dairy != null)
            {

                await _context.Daily_records.AddAsync(data);
                await _context.SaveChangesAsync();
                return Ok(await _context.Daily_records.ToListAsync<Daily_record>());
            }
            else
            {
                logger.Warn("Dairy not existed");
                return BadRequest("Dairy Id not found");
            }


        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> delete(int id)
        {
            Daily_record data = _context.Daily_records.Where(x => x.Dairy_Id == id).FirstOrDefault();

            if (data == null)
            {
                logger.Warn("Attempt to delete daily record failed becuase the data not existed");
                return BadRequest("no data found on this id");
            }
            _context.Daily_records.Remove(data);
            await _context.SaveChangesAsync();
            return Ok(await _context.Daily_records.ToListAsync<Daily_record>());


        }
    }
}
