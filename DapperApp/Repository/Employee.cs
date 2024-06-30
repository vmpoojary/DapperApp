using Dapper;
using DapperApp.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Dynamic;
using System.Data;

namespace DapperApp.Repository
{
    public class Employee : IEmployee
    {
        private IDbConnection dbSqlServer;
        private IDbConnection dbOracleServer;

        public Employee(IConfiguration configuration)
        {
            dbSqlServer = new SqlConnection(configuration.GetConnectionString("SqlServer"));
            dbOracleServer = new OracleConnection(configuration.GetConnectionString("OracleServer"));
        }

        

        public async Task<object> GetEmployees()
        {
            var response= await dbSqlServer.QueryAsync("select * from EmployeeMaster");
            return response;
        }

        public async Task<object> GetEmployee(string id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("id", id);
            var response = await dbSqlServer.QueryAsync("SP_GETEMPLOYEE",parameters, commandType: CommandType.StoredProcedure);
            return response;
        }

        public async Task<object> GetEmployeeO()
        {
            var response = await dbOracleServer.QueryAsync("select * from employeemaster");
            return response;
        }

        public async Task<object> GetEmployeesO(string id)
        {
            
            OracleDynamicParameters parameters= new OracleDynamicParameters();
            parameters.Add("P_SRNO", value: id);
            parameters.Add("cv_results",dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);
            using(var response = await dbOracleServer.QueryMultipleAsync("SP_GETEMPLOYEEMASTER", parameters, commandType: CommandType.StoredProcedure))
            {
                var data = response.Read();
                return data;
            }


            //var result = parameters.Get<object>("cv_results");
            //return result;
        }
    }
}
