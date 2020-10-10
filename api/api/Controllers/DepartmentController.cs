using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using api.BLL.Logics;

namespace api.Controllers.WebService
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private DepartmentLogic _DepartmentLogic;

        
        public DepartmentController(IConfiguration configuration)
        {
            _DepartmentLogic = new DepartmentLogic(configuration);
        }

        // GET 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data>>> GetAsync()
        {
            var select = await _DepartmentLogic.dep_select_Logic();

            return Ok(select); 
        }

        // POST 
        [HttpPost]
        public async Task<string> Post([FromForm] data value)
        {
            string insert = await _DepartmentLogic.dep_insert_Logic();

            return insert;
        }

        // PUT
        [HttpPut]
        public async Task<string> Put([FromForm] data value)
        {
            string update = await _DepartmentLogic.dep_update_Logic();

            return update;
        }

        // DELETE 
        [HttpDelete]
        public async Task<string> Delete([FromForm] data value)
        {
            string delete = await _DepartmentLogic.dep_delete_Logic();

            return delete;
        }
    }
}
