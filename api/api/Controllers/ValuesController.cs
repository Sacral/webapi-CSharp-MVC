using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.connection;
using api.Model;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IConfiguration _configuration;
        private ConnectionFactory _connectionFactory;
        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionFactory = new ConnectionFactory(_configuration);
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<data>> Get()
        {
            var cn = _connectionFactory.CreateConnection();
            
            var sql = "SELECT * FROM [AdventureWorks2019].[HumanResources].[Department] WHERE DepartmentID = @DepartmentID ";

            var dataList = cn.Query<data>(sql, new { DepartmentID = 1 }).ToList();

            return dataList;
        }

        // POST api/values
        [HttpPost]
        public ActionResult<IEnumerable<data>> Post([FromBody] string value)
        {

            var cn = _connectionFactory.CreateConnection();

            var sql = "INSERT INTO [AdventureWorks2019].[HumanResources].[Department] ( Name, GroupName,ModifiedDate) VALUES (@Name, @GroupName, @ModifiedDate)";

            var newdata = new data
            {
                Name = "test2",
                GroupName = "test2",
                ModifiedDate = DateTime.Now,
            };

            cn.Execute(sql, newdata);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
