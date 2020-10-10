using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DAL.Managers;
using api.Model;
using Microsoft.Extensions.Configuration;



namespace api.BLL.Logics
{
    public class DepartmentLogic
    {
        private DepartmentManagers _DepartmentManagers;

        public DepartmentLogic(IConfiguration configuration)
        {
            _DepartmentManagers = new DepartmentManagers(configuration);
        }

        // GET 

        public async Task<IEnumerable<data>> dep_select_Logic()
        {
            var select = await _DepartmentManagers.DepartmentSelect();

            return  select;
        }

        // POST 

        public async Task<string> dep_insert_Logic()
        {
            string insert = await _DepartmentManagers.DepartmentInsert();

            return insert;
        }

        // PUT

        public async Task<string> dep_update_Logic()
        {
            string update = await _DepartmentManagers.DepartmentUpdate();

            return update;
        }

        // DELETE 

        public async Task<string> dep_delete_Logic()
        {
            string delete = await _DepartmentManagers.DepartmentDelete();

            return delete;
        }



    }
}
