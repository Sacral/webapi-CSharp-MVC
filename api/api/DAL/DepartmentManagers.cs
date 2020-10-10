using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.connection;
using api.Model;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace api.DAL.Managers
{
    public class DepartmentManagers
    {

        private IConfiguration _configuration;
        private ConnectionFactory _connectionFactory;

        public DepartmentManagers(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionFactory = new ConnectionFactory(_configuration);
        }


        public async Task<IEnumerable<data>> DepartmentSelect()
        {
            var cn = _connectionFactory.CreateConnection();

            var sql = "SELECT * FROM [AdventureWorks2019].[HumanResources].[Department] WHERE DepartmentID = @DepartmentID ";

            var dataList = cn.Query<data>(sql, new { DepartmentID = 1 }).ToList();

            return dataList;
        }


        public async Task<string> DepartmentInsert()
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

            return "insert ok";
        }

        public async Task<string> DepartmentUpdate()
        {
            var cn = _connectionFactory.CreateConnection();

            var sql = "UPDATE [AdventureWorks2019].[HumanResources].[Department] SET  Name = @Name, GroupName = @GroupName,ModifiedDate = @ModifiedDate WHERE DepartmentID = @DepartmentID   ";

            var newdata = new data
            {
                DepartmentID = 21,
                Name = "test3",
                GroupName = "test2",
                ModifiedDate = DateTime.Now,
            };

            cn.Execute(sql, newdata);

            return "update ok";
        }

        public async Task<string> DepartmentDelete()
        {
            var cn = _connectionFactory.CreateConnection();

            var sql = "DELETE FROM [AdventureWorks2019].[HumanResources].[Department] WHERE DepartmentID = @DepartmentID   ";

            var newdata = new data
            {
                DepartmentID = 21,
            };

            cn.Execute(sql, newdata);

            return "delete ok";
        }


    }
}
