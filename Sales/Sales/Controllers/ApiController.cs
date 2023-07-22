using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.Database;

using Sales.models;

namespace Sales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly datacontext _context;
        private readonly ILog _logger;

        public ApiController(datacontext context)
        {
            _context = context;
            this._logger = LogManager.GetLogger(typeof(ApiController));
        }
      

        [HttpGet("get")]
        public  IActionResult get()
        {

            return Ok( _context.sales.ToList<sales>());
            
        }

        [HttpPost("add")]
        public   IActionResult add(sales data)
        {

            if(data==null)
            {
                _logger.Error("Attempt to creating invalid sales object");
                return BadRequest("enter proper details");
            }
            _context.sales.Add(data);   
            _context.SaveChanges();
            return Ok( _context.sales.ToList<sales>());
        }


        [HttpPut("update")]
        public IActionResult update(sales data)
        {
            
            if (data.type == 2)
            {
                sales sales =  _context.sales.Where(x => x.id == data.id).FirstOrDefault<sales>();
                if (sales == null)
                {
                    _logger.Warn("Id not present in databse ");
                    return BadRequest("no data found on this id");
                }


                sales.quantity = sales.quantity - data.data;
                sales.sold = data.data+ sales.sold;
                 _context.SaveChanges();
                return Ok( _context.sales.ToList<sales>());
            }
            else if (data.type == 1)
            {
                sales sales =  _context.sales.Where(x => x.id == data.id).FirstOrDefault<sales>();
                if (sales == null)
                {
                    _logger.Warn("Id not present in databse ");
                    return BadRequest("no data found on this id");
                }
                sales.quantity = sales.quantity + data.data;
                 _context.SaveChanges();
                return Ok( _context.sales.ToList<sales>());
            }

            _logger.Warn("Attempt to update sales object failed beacuse of wrong type of update mode ");
            return BadRequest("enter proper type");




        }

        [HttpDelete("delete/{id}")]
        public  IActionResult delete(int id)
        {
            sales data= _context.sales.Where(x=>x.id==id).FirstOrDefault();
            if (data == null)
            {
                _logger.Error("Attempt to delete non-existing  sales object");
                return BadRequest("no data found on this id");
            }
            _context.sales.Remove(data);
             _context.SaveChanges();
            return Ok( _context.sales.ToList<sales>());


        }

    }
}
