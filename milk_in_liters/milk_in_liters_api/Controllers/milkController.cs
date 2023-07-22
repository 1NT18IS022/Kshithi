using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using milk_in_liters_api.database;
using milk_in_liters_api.model;

namespace milk_in_liters_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class milkController : ControllerBase
    {
        private readonly datacontext _context;
        private readonly ILogger<milkController> _logger;


        public milkController(datacontext context, ILogger<milkController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<milk>> getdetails()
        {
            List<milk> data = await _context.milks.ToListAsync<milk>();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<milk>>> detailsbyid(int id)
        {
            List<milk> data = await _context.milks.Where(x => x.member_Id == id).ToListAsync<milk>();
            if (data == null)
            {
                _logger.LogWarning("milk record  not present on given id");
                return BadRequest("not found");
            }
            return data;
        }

        [HttpPost]
        public async Task<ActionResult<milk>> addMilk(milk newData)
        {

            if (newData == null)
            {
                _logger.LogWarning("Attempt to create milk object failed");
                return BadRequest("please enter all details properly");
            }

            member person=await _context.members.FindAsync(newData.member_Id);



            if (person != null)
            {
                milk check = await _context.milks.Where(x => x.member_Id == newData.member_Id).FirstOrDefaultAsync<milk>();


                if (check != null)
                {

                    List<milk> data = _context.milks.Where(x => x.member_Id == newData.member_Id).ToList<milk>();

                    data.OrderByDescending(x => x.member_Id);
                    milk pre = data.Last<milk>();
                    newData.total_liters = pre.total_liters + newData.liters;


                    _context.milks.Add(newData);
                    await _context.SaveChangesAsync();
                }
                else
                {


                    newData.total_liters = newData.liters;
                    await _context.milks.AddAsync(newData);
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                _logger.LogError("Attempt to add milk record failed because the member id not existed");
                return BadRequest("member id not found");

            }
            

            return Ok(await _context.milks.ToListAsync());

        }

    }

}
