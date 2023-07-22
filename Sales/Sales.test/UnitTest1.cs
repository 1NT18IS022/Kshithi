using Castle.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sales.Controllers;
using Sales.Database;
using Sales.models;
using System.Net.WebSockets;
using System.Numerics;
using System.Xml.Linq;

namespace Sales.test
{
    public class Tests
    {
        private datacontext getdatacontext()
        {
            var options = new DbContextOptionsBuilder<datacontext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var databasecontext = new datacontext(options);
            databasecontext.Database.EnsureCreated();
            if (databasecontext.sales.Count() <= 0)
            {
                databasecontext.sales.Add(new sales()
                {
                    id = 1,
                    name = "mamama",
                    price = 678,
                    quantity = 50,
                    date = DateTime.Now,

                });
                databasecontext.SaveChanges();

            }
            return databasecontext;
        }

      private readonly  ApiController controller;
       
        [SetUp]
        public void Setup()
        {
            ApiController controller = new ApiController(getdatacontext());
        }

        [Test]
        public void check_returnall()
        {
            IEnumerable<sales> players = new List<sales>();
            ApiController home = new ApiController(getdatacontext());
            

            var result = home.get();
          
           
             Assert.NotNull(result);
        }

        [Test]
        public void check_add()
        {
           

            ApiController home = new ApiController(getdatacontext());
            sales obj=new sales()
                 {

                    name = "mamama",
                    price = 678,
                    quantity = 50,
                    date = DateTime.Now,

                
            };
            var result = home.add(obj);
            var okresult = result as OkObjectResult;

            Assert.IsNotNull(okresult);
            Assert.AreEqual(200, okresult.StatusCode);


        }
        [Test]
        public void check_delete()
        {

            ApiController home = new ApiController(getdatacontext());
            var id = 100;
            sales obj = new sales()
            {
                id= id,
        };

        var res=home.delete(obj.id);
        var badrequest=res as BadRequestObjectResult;

        Assert.IsNotNull(badrequest);
            Assert.AreEqual(400,badrequest.StatusCode);




        }
    }
}