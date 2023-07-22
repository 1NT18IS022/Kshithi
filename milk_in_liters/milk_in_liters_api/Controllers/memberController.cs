using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using milk_in_liters_api.database;
using milk_in_liters_api.model;

namespace milk_in_liters_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class memberController : ControllerBase
    {
        private readonly datacontext _context;
        private readonly ILogger<memberController> _logger;

        public memberController(datacontext context, ILogger<memberController> logger)
        {
            _context = context;
            _logger = logger;
        }



        [HttpGet]
        public async Task<ActionResult<member>> getdata()
        {
            return Ok(await _context.members.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<member>> byId(int id)
        {
            var req = await _context.members.FirstOrDefaultAsync(x => x.member_Id == id);
            return Ok(req);
        }


        [HttpPost("add")]
        public async Task<ActionResult<List<member>>> adddetails(member data)
        {
            if (data == null)
            {
                _logger.LogError("Attempt to add invalid member object");
                BadRequest("enter proper details");
            }
            _context.members.Add(data);

            await _context.SaveChangesAsync();
             return Ok(await _context.members.ToListAsync());
        }
/*
        [HttpPut("update")]
        public async Task<ActionResult<List<member>>> update(member data, int id)
        {
            if (data == null)
                BadRequest("enter proper details");

            member y = await _context.members.Where(x => x.member_Id == id).FirstOrDefaultAsync<member>();

            if (y != null)
            {
                y.phone_number = data.phone_number;
                y.aadhar_number = data.aadhar_number;
                y.member_Name = data.member_Name;
                y.gender = data.gender;
                y.age = data.age;


            }
            else
                return BadRequest("not found");

            await _context.SaveChangesAsync();
             return Ok(await _context.members.ToListAsync());

        }*/

        [HttpPut("update")]
        public async Task<ActionResult<member>> update(member data)
        {
            if (data == null)
            {
                _logger.LogError("Attempt to update with null data");
                BadRequest("enter proper details");
            }

            member y = await _context.members.Where(x => x.member_Id == data.member_Id).FirstOrDefaultAsync<member>();

            if (y != null)
            {
                y.phone_number = data.phone_number;
                y.aadhar_number = data.aadhar_number;
                y.member_Name = data.member_Name;
                y.gender = data.gender;
                y.age = data.age;


            }
            else
            {
                _logger.LogWarning("Attempt to update member object failde because the member is not exist in database");
                return BadRequest("not found");
            }

            await _context.SaveChangesAsync();

            return Ok(await _context.members.ToListAsync());

        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<member>> delete(int id)
        {
            member y = await _context.members.FindAsync(id);
            if (y == null)
            {
                _logger.LogError("Attempt to delete non-exist member object");
                return BadRequest("user not found");

            }
            _context.members.Remove(y);
            await _context.SaveChangesAsync();

            return Ok(await _context.members.ToListAsync());
        }
    }
}

