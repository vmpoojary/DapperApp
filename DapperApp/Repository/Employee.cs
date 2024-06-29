using Dapper;
using DapperApp.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;

namespace DapperApp.Repository
{
    public class Employee : IEmployee
    {
        private IDbConnection db;

        public Employee(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetConnectionString("SqlServer"));
        }

        

        public async Task<object> GetEmployees()
        {
            var response= await db.QueryAsync("select * from EmployeeMaster");
            return response;
        }

        public async Task<object> GetEmployee(string id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("id", id);
            var response = await db.QueryAsync("SP_GETEMPLOYEE",parameters, commandType: CommandType.StoredProcedure);
            return response;
        }


    }
}
